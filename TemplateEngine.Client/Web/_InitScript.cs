using Neptuo.Bootstrap;
using Neptuo.Bootstrap.Constraints;
using Neptuo.Client.Compilation;
using Neptuo.Lifetimes;
using Neptuo.ObjectBuilder;
using Neptuo.ObjectBuilder.Lifetimes.Mapping;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Permissions;
using Neptuo.TemplateEngine.PresentationModels;
using Neptuo.TemplateEngine.Web.Controllers;
using Neptuo.TemplateEngine.Web.Controllers.Binders;
using Neptuo.Templates;
using SharpKit.Html;
using SharpKit.JavaScript;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public static class InitScript
    {
        public static FormRequestContext FormRequestContext;
        private static IDependencyContainer dependencyContainer;
        private static IViewActivator viewActivator;
        private static IHistoryState historyState;
        private static IMainView mainView;

        private static IDependencyContainer CreateDependencyContainer()
        {
            DependencyContainer container = new DependencyContainer();
            container
                .Map(typeof(SingletonLifetime), new SingletonLifetimeMapper());

            DefaultFormUriService formService = new DefaultFormUriService();
            FormUriServiceRegistration.SetInstance(formService);

            viewActivator = new StaticViewActivator(container);
            historyState = new HistoryState();
            mainView = new MainView(viewActivator);

            container
                .RegisterType<IStackStorage<IViewStorage>, StackStorage<IViewStorage>>()
                .RegisterType<IVirtualUrlProvider, UrlProvider>()
                .RegisterType<ICurrentUrlProvider, UrlProvider>()
                .RegisterType<IParameterProviderFactory, ParameterProviderFactory>()
                .RegisterType<IParameterProvider, AllParameterProvider>()
                .RegisterType<IBindingManager, BindingManagerBase>()
                .RegisterType<IValueConverterService, ValueConverterService>()
                .RegisterType<IRequestContext, CompositeRequestContext>()
                .RegisterInstance(new TemplateContentStorageStack())
                .RegisterInstance(new DataContextStorage())
                .RegisterInstance<IGuidProvider>(new SequenceGuidProvider("guid", 1))
                .RegisterInstance<IViewActivator>(viewActivator)

                .RegisterInstance(new GlobalNavigationCollection())

                .RegisterInstance<IFormUriService>(formService)
                .RegisterInstance<IFormUriRegistry>(formService)

                .RegisterInstance<IControllerRegistry>(new ControllerRegistryBase())
                .RegisterInstance<IPermissionProvider>(new OptimisticPermissionProvider())

                .RegisterInstance<IHistoryState>(historyState)
                .RegisterInstance<IMainView>(mainView);

            return container;
        }

        private static void RunBootstrapTasks(IDependencyContainer objectBuilder)
        {
            Func<Type, IBootstrapTask> taskFactory = (type) => objectBuilder.Resolve(type, null).As<IBootstrapTask>();
            Func<Type, IBootstrapConstraint> constrainFactory = (type) => objectBuilder.Resolve(type, null).As<IBootstrapConstraint>();

            IBootstrapper bootstrapper = new AutomaticBootstrapper(taskFactory, JsCompiler.NewTypes.As<JsArray<Type>>(), new AttributeConstraintProvider(constrainFactory));
            bootstrapper.Initialize();
        }

        public static void Init()
        {
            dependencyContainer = CreateDependencyContainer();

            Converts.Repository
                .Add(typeof(JsObject), typeof(PartialResponse), new PartialResponseConverter());

            RunBootstrapTasks(dependencyContainer);

            historyState.OnPop += historyState_OnPop;

            mainView.OnLinkClick += mainView_OnLinkClick;
            mainView.OnGetFormSubmit += mainView_OnGetFormSubmit;
            mainView.OnPostFormSubmit += mainView_OnPostFormSubmit;
        }

        private static void historyState_OnPop(HistoryItem historyItem)
        {
            if (historyItem != null)
            {
                if (historyItem.FormData != null)
                    FormRequestContext = new FormRequestContext(historyItem.ToUpdate, historyItem.FormData, historyItem.EventName, historyItem.Url);
                else
                    FormRequestContext = null;

                RenderUrl(historyItem.Url, String.Join(",", historyItem.ToUpdate.As<IEnumerable<string>>()));
            }
            else
            {
                FormRequestContext = null;
                RenderUrl(HtmlContext.location.href, "Body");
            }
        }

        //TODO: Router...
        public static string MapView(string url)
        {
            if (url.Contains("/Home.aspx"))
                return "~/Views/Home.view";

            if (url.Contains("/Accounts/UserList.aspx"))
                return "~/Views/Accounts/UserList.view";

            if (url.Contains("/Accounts/UserEdit.aspx"))
                return "~/Views/Accounts/UserEdit.view";

            if (url.Contains("/Accounts/RoleList.aspx"))
                return "~/Views/Accounts/RoleList.view";

            if (url.Contains("/Accounts/RoleEdit.aspx"))
                return "~/Views/Accounts/RoleEdit.view";

            return null;
        }

        private static void mainView_OnLinkClick(string newUrl, string[] toUpdate)
        {
            NavigateToUrl(newUrl, String.Join(",", toUpdate.As<IEnumerable<string>>()), "");
        }

        private static void mainView_OnGetFormSubmit(string newUrl, string[] toUpdate)
        {
            NavigateToUrl(newUrl, String.Join(",", toUpdate.As<IEnumerable<string>>()), "");
        }

        private static void mainView_OnPostFormSubmit(FormRequestContext context)
        {
            FormRequestContext = context;
            historyState.Replace(new HistoryItem(context.FormUrl, context.ToUpdate, context));

            if (!InvokeControllers(context.Parameters))
            {
                HtmlContext.alert("Event: " + context.EventName);
                HtmlContext.console.log(context.Parameters);

                JsObject headers = new JsObject();
                headers["X-EngineRequestType"] = "Partial";
                jQuery.ajax(new AjaxSettings
                {
                    url = context.FormUrl,
                    type = "POST",
                    data = context.Parameters,
                    headers = headers,
                    success = OnFormSubmitSuccess
                });
            }
        }

        private static void NavigateToUrl(string newUrl, string toUpdate, string title, Action<IDependencyContainer> initContainer = null)
        {
            string viewPath = MapView(newUrl);

            historyState.Push(new HistoryItem(newUrl, null));
            RenderUrl(newUrl, toUpdate, initContainer);
        }

        private static void RenderUrl(string newUrl, string toUpdate, Action<IDependencyContainer> initContainer = null)
        {
            string viewPath = MapView(newUrl);
            if (viewPath == null)
            {
                HtmlContext.alert("No view for: " + newUrl);
                //TODO: Create classic redirect...
                HtmlContext.window.location.href = newUrl;
                return;
            }

            IDependencyContainer container = dependencyContainer.CreateChildContainer();
            if (initContainer != null)
                initContainer(container);

            List<string> partialsToUpdate = new List<string>();
            if (!String.IsNullOrEmpty(toUpdate))
            {
                foreach (string partialToUpdate in toUpdate.Split(','))
                    partialsToUpdate.Add(partialToUpdate);
            }
            else
            {
                partialsToUpdate.Add("Body");
            }

            mainView.RenderView(viewPath, partialsToUpdate.ToArray(), container);
        }

        private static void OnFormSubmitSuccess(object response, JsString status, jqXHR sender)
        {
            PartialResponse partialResponse;
            if (Converts.Try<JsObject, PartialResponse>(response.As<JsObject>(), out partialResponse))
            {
                string navigationUrl = null;
                if (partialResponse.Navigation != null)
                    navigationUrl = dependencyContainer.Resolve<IVirtualUrlProvider>().ResolveUrl(partialResponse.Navigation);
                else
                    navigationUrl = HtmlContext.location.pathname;

                NavigateToUrl(
                    navigationUrl, 
                    String.Join(",", FormRequestContext.ToUpdate.As<IEnumerable<string>>()), 
                    "Form submitted", 
                    container => container.RegisterInstance<MessageStorage>(partialResponse.Messages)
                );
                FormRequestContext = null;
            }
            else
            {
                HtmlContext.alert(status);
            }
        }

        private static bool InvokeControllers(JsArray data)
        {
            IDependencyContainer container = dependencyContainer.CreateChildContainer();
            container.RegisterInstance<IParameterProvider>(new DictionaryParameterProvider(TransformParameters(data)));

            IControllerRegistry controllerRegistry = container.Resolve<IControllerRegistry>();
            ViewDataCollection viewData = new ViewDataCollection();
            IModelBinder modelBinder = container.Resolve<IModelBinder>();
            NavigationCollection localNavigations = new NavigationCollection();
            bool isControllerExecuted = false;

            for (int i = 0; i < data.length; i++)
            {
                string key = data[i].As<JsObject>()["name"].As<string>();

                IController controller;
                if (controllerRegistry.TryGet(key, out controller))
                {
                    controller.Execute(new ControllerContext(key, viewData, modelBinder, localNavigations));
                    isControllerExecuted = true;
                }
            }

            return isControllerExecuted;
        }

        private static Dictionary<string, string> TransformParameters(JsArray data)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            for (int i = 0; i < data.length; i++)
                parameters[data[i].As<JsObject>()["name"].As<string>()] = data[i].As<JsObject>()["value"].As<string>();

            return parameters;
        }
    }

    public class UrlProvider : IVirtualUrlProvider, ICurrentUrlProvider
    {
        public string ResolveUrl(string path)
        {
            return path.Replace("~/", "/");
        }

        public string GetCurrentUrl()
        {
            return HtmlContext.location.href;
        }
    }

    public class ParameterProviderFactory : IParameterProviderFactory
    {
        public IParameterProvider Provider(ParameterProviderType providerType)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            switch (providerType)
            {
                case ParameterProviderType.All:
                    ParseQueryString(parameters);
                    ParseFormRequest(parameters);
                    break;
                case ParameterProviderType.Url:
                    ParseQueryString(parameters);
                    break;
                case ParameterProviderType.Form:
                    ParseFormRequest(parameters);
                    break;
                default:
                    break;
            }
            return new DictionaryParameterProvider(parameters);
        }

        public static void ParseQueryString(Dictionary<string, string> parameters)
        {
            string queryString = HtmlContext.location.search;
            if (String.IsNullOrEmpty(queryString))
                return;

            if (queryString.StartsWith("?"))
                queryString = queryString.Substring(1);

            string[] keyValues = queryString.Split('&');
            foreach (string keyValue in keyValues)
            {
                string[] param = keyValue.Split('=');
                if (param.Length == 2)
                    parameters[param[0]] = param[1];
                else
                    parameters[param[0]] = null;
            }
        }

        public static void ParseFormRequest(Dictionary<string, string> parameters)
        {
            if (InitScript.FormRequestContext != null)
            {
                JsArray source = InitScript.FormRequestContext.Parameters;
                for (int i = 0; i < source.length; i++)
                {
                    JsObject parameter = source[i].As<JsObject>();
                    parameters[parameter["name"].As<string>()] = parameter["value"].As<string>();
                }
            }
        }
    }

    public class AllParameterProvider : DictionaryParameterProvider
    {
        public AllParameterProvider()
            : base(new Dictionary<string,string>())
        {
            ParameterProviderFactory.ParseQueryString(Parameters);
            ParameterProviderFactory.ParseFormRequest(Parameters);
        }
    }

    public class FormRequestContext
    {
        public string[] ToUpdate { get; private set; }
        public JsArray Parameters { get; private set; }
        public string EventName { get; private set; }
        public string FormUrl { get; private set; }

        public FormRequestContext(string[] toUpdate, JsArray parameters, string eventName, string formUrl)
        {
            ToUpdate = toUpdate;
            Parameters = parameters;
            EventName = eventName;
            FormUrl = formUrl;
        }
    }

}

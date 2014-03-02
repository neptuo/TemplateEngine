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

        private static IDependencyContainer CreateDependencyContainer()
        {
            DependencyContainer container = new DependencyContainer();
            container
                .Map(typeof(SingletonLifetime), new SingletonLifetimeMapper());

            DefaultFormUriService formService = new DefaultFormUriService();
            FormUriServiceRegistration.SetInstance(formService);

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
                .RegisterType<IViewActivator, StaticViewActivator>(new SingletonLifetime())
                
                .RegisterInstance(new GlobalNavigationCollection())

                .RegisterInstance<IFormUriService>(formService)
                .RegisterInstance<IFormUriRegistry>(formService)

                .RegisterInstance<IControllerRegistry>(new ControllerRegistryBase())
                .RegisterInstance<IPermissionProvider>(new OptimisticPermissionProvider());

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
            viewActivator = dependencyContainer.Resolve<IViewActivator>();

            Converts.Repository
                .Add(typeof(JsObject), typeof(PartialResponse), new PartialResponseConverter());

            RunBootstrapTasks(dependencyContainer);

            new jQuery(() => {
                jQuery body = new jQuery("body");

                body.@delegate("a", "click", OnLinkClick);
                body.@delegate("button", "click", OnButtonClick);
                body.@delegate("form", "submit", OnFormSubmit);
            });

            HtmlContext.window.addEventListener("popstate", OnPopState);
        }

        private static void OnPopState(DOMEvent e)
        {
            PopStateEvent state = e.As<PopStateEvent>();
            RenderUrl(HtmlContext.location.href, "Body");
            //NavigateToUrl(HtmlContext.location.href, "Body", "Go back");
        }

        public static void UpdateContent(string partialGuid, TextWriter content)
        {
            jQuery target = new jQuery("div[data-partial=" + partialGuid + "]");
            target.replaceWith(content.ToString());

            target.find("a").click(OnLinkClick);
        }

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

        public static void OnLinkClick(Event e)
        {
            jQuery link = new jQuery(e.currentTarget);
            e.preventDefault();
            
            RenderViewFromLink(link);
        }

        private static void RenderViewFromLink(jQuery link)
        {
            string newUrl = link.attr("href");
            string toUpdate = link.data("toupdate").As<string>();
            string title = link.html();
            NavigateToUrl(newUrl, toUpdate, title);
        }

        private static void NavigateToUrl(string newUrl, string toUpdate, string title, Action<IDependencyContainer> initContainer = null)
        {
            string viewPath = MapView(newUrl);
            HtmlContext.history.pushState(viewPath, title, newUrl);
            RenderUrl(newUrl, toUpdate, initContainer);
        }

        private static void RenderUrl(string newUrl, string toUpdate, Action<IDependencyContainer> initContainer = null)
        {
            string viewPath = MapView(newUrl);
            if (viewPath == null)
            {
                HtmlContext.alert("No view for: " + newUrl);
                return;
            }

            IDependencyContainer container = dependencyContainer.CreateChildContainer();

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

            ClientExtendedComponentManager componentManager = new ClientExtendedComponentManager(partialsToUpdate);
            container
                .RegisterInstance<IComponentManager>(componentManager)
                .RegisterInstance<IPartialUpdateWriter>(componentManager)
                .RegisterInstance<NavigationCollection>(new NavigationCollection());

            if (initContainer != null)
                initContainer(container);

            StringWriter writer = new StringWriter();
            var view = viewActivator.CreateView(viewPath);
            view.Setup(new BaseViewPage(componentManager), componentManager, container);
            view.CreateControls();
            view.Init();
            view.Render(new ExtendedHtmlTextWriter(writer));
            view.Dispose();
        }

        private static void OnFormSubmit(Event e)
        {
            jQuery form = new jQuery(e.currentTarget);
            JsArray data = form.serializeArray();
            string buttonName = form.data("button").As<string>();
            if(String.IsNullOrEmpty(buttonName))
                buttonName = form.find("button:first").attr("name");

            JsObject submitButton = new JsObject();
            submitButton["name"] = buttonName;
            submitButton["value"] = null;
            data.push(submitButton);

            FormRequestContext context = new FormRequestContext(data, buttonName, form.attr("action") ?? HtmlContext.location.href);
            FormRequestContext = context;

            if (!InvokeControllers(data))
            {
                HtmlContext.alert("Event: " + buttonName);
                HtmlContext.console.log(data);

                JsObject headers = new JsObject();
                headers["X-EngineRequestType"] = "Partial";
                jQuery.ajax(new AjaxSettings
                {
                    url = form.attr("action"),
                    type = form.attr("method"),
                    data = data,
                    headers = headers,
                    success = OnFormSubmitSuccess
                });
            }

            e.preventDefault();
        }

        private static void OnFormSubmitSuccess(object response, JsString status, jqXHR sender)
        {
            //if (response != null && response.As<JsObject>()["Navigation"] != null)
            //    NavigateToUrl(response.As<JsObject>()["Navigation"].As<string>(), "Body", "Form submitted");
            //else
            //    HtmlContext.alert(status);

            PartialResponse partialResponse;
            if (Converts.Try<JsObject, PartialResponse>(response.As<JsObject>(), out partialResponse))
            {
                string navigationUrl = null;
                if (partialResponse.Navigation != null)
                    navigationUrl = dependencyContainer.Resolve<IVirtualUrlProvider>().ResolveUrl(partialResponse.Navigation);
                else
                    navigationUrl = HtmlContext.location.pathname;
                
                NavigateToUrl(navigationUrl, "Body", "Form submitted", container => container.RegisterInstance<MessageStorage>(partialResponse.Messages));
                FormRequestContext = null;
            }
            else
            {
                HtmlContext.alert(status);
            }
        }

        private static void OnButtonClick(Event e)
        {
            jQuery button = new jQuery(e.currentTarget);
            string buttonName = button.attr("name");
            button.parents("form").first().data("button", buttonName);
        }

        private static bool InvokeControllers(JsArray data)
        {
            IDependencyContainer container = dependencyContainer.CreateChildContainer();
            container.RegisterInstance<IParameterProvider>(new ParameterProvider(TransformParameters(data)));

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
            return new ParameterProvider(parameters);
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

    public class ParameterProvider : IParameterProvider
    {
        protected Dictionary<string, string> Parameters { get; private set; }

        public ParameterProvider(Dictionary<string, string> parameters)
        {
            Parameters = parameters;
        }

        public IEnumerable<string> Keys
        {
            get { return Parameters.Keys; }
        }

        public bool TryGet(string key, out object value)
        {
            string targetValue;
            if (Parameters.TryGetValue(key, out targetValue))
            {
                value = targetValue;
                return true;
            }

            value = null;
            return false;
        }
    }

    public class AllParameterProvider : ParameterProvider
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
        public JsArray Parameters { get; private set; }
        public string Event { get; private set; }
        public string FormUrl { get; private set; }

        public FormRequestContext(JsArray parameters, string eventName, string formUrl)
        {
            Parameters = parameters;
            Event = eventName;
            FormUrl = formUrl;
        }
    }

}

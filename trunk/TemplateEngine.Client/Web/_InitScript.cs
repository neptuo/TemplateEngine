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

        public static void Init()
        {
            Application.Start("/", new string[] { "Body" });
            dependencyContainer = Application.Instance.DependencyContainer;

            Application.Instance.HistoryState.OnPop += historyState_OnPop;

            Application.Instance.MainView.OnLinkClick += mainView_OnLinkClick;
            Application.Instance.MainView.OnGetFormSubmit += mainView_OnGetFormSubmit;
            Application.Instance.MainView.OnPostFormSubmit += mainView_OnPostFormSubmit;
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
            //FormRequestContext = context;
            //historyState.Replace(new HistoryItem(context.FormUrl, context.ToUpdate, context));

            if (!InvokeControllers(context.Parameters))
                Application.Instance.FormPostInvokers.Invoke(new FormPostInvoker(Application.Instance, dependencyContainer, context));
        }

        private static void NavigateToUrl(string newUrl, string toUpdate, string title, Action<IDependencyContainer> initContainer = null)
        {
            string viewPath = MapView(newUrl);

            Application.Instance.HistoryState.Push(new HistoryItem(newUrl, null));
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

            Application.Instance.MainView.RenderView(viewPath, partialsToUpdate.ToArray(), container);
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

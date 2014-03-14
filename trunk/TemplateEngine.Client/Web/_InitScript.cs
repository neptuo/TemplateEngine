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

        private static bool InvokeControllers(JsArray data)
        {
            IDependencyContainer container = Application.Instance.DependencyContainer.CreateChildContainer();
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

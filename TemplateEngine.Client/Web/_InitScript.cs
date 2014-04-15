using Neptuo.Bootstrap;
using Neptuo.Bootstrap.Constraints;
using Neptuo.Client.Compilation;
using Neptuo.Collections.Generic;
using Neptuo.Lifetimes;
using Neptuo.ObjectBuilder;
using Neptuo.ObjectBuilder.Lifetimes.Mapping;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.PresentationModels;
using Neptuo.TemplateEngine.Routing;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
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
using Neptuo.TemplateEngine.Providers;

namespace Neptuo.TemplateEngine.Web
{
    public static class InitScript
    {
        private static bool InvokeControllers(JsArray data)
        {
            IDependencyContainer container = Application.Instance.DependencyContainer.CreateChildContainer();
            container.RegisterInstance<IParameterProvider>(new DictionaryParameterProvider(TransformParameters(data)));

            IControllerRegistry controllerRegistry = container.Resolve<IControllerRegistry>();
            IModelBinder modelBinder = container.Resolve<IModelBinder>();
            NavigationCollection localNavigations = new NavigationCollection();
            MessageStorage messageStorage = container.Resolve<MessageStorage>();
            bool isControllerExecuted = false;

            for (int i = 0; i < data.length; i++)
            {
                string key = data[i].As<JsObject>()["name"].As<string>();

                IController controller;
                if (controllerRegistry.TryGet(key, out controller))
                {
                    controller.Execute(new ControllerContext(key, modelBinder, container, localNavigations, messageStorage));
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
}

using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controllers;
using Neptuo.TemplateEngine.Web.Controllers.Binders;
using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace Neptuo.TemplateEngine.Backend.Web
{
    public abstract class TemplateHttpHandlerBase : IHttpHandler, IRequiresSessionState
    {
        public const string EngineRequestType = "X-EngineRequestType";
        public const string EngineRequestTypePartial = "Partial";

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext httpContext)
        {
            Guard.NotNull(httpContext, "context");

            IDependencyContainer dependencyContainer = GetDependencyContainer().CreateChildContainer();
            NavigationCollection navigations = dependencyContainer.Resolve<NavigationCollection>();
            GlobalNavigationCollection globalNavigations = dependencyContainer.Resolve<GlobalNavigationCollection>();
            HandleUiEvents(httpContext, dependencyContainer, navigations);

            if (httpContext.Request.Headers[EngineRequestType] == EngineRequestTypePartial)
            {
                // Partial ajax request - serialize messages and navigations
                MessageStorage messageStorage = dependencyContainer.Resolve<MessageStorage>();
                
                string redirectUrl = null;
                FormUri to;
                if (globalNavigations.TryGetValue(navigations.FirstOrDefault(), out to))
                    redirectUrl = to.Url();

                //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                //string response = javaScriptSerializer.Serialize(new PartialResponse(messageStorage, redirectUrl));

                string response = JsonConvert.SerializeObject(new PartialResponse(messageStorage, redirectUrl));
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.Write(response);
            }
            else
            {
                // Standart request - process redirects and eventually rerender current view
                INavigator navigator = dependencyContainer.Resolve<INavigator>();
                if (!ProcessNavigationRules(navigations, globalNavigations, navigator))
                {
                    BaseGeneratedView view = GetCurrentView(httpContext);
                    ExtendedComponentManager componentManager = GetComponentManager(httpContext);

                    dependencyContainer.RegisterInstance<IComponentManager>(componentManager);
                    dependencyContainer.RegisterInstance<IPartialUpdateWriter>(componentManager);

                    view.Setup(new BaseViewPage(componentManager), componentManager, dependencyContainer);
                    view.CreateControls();
                    view.Init();
                    view.Render(new ExtendedHtmlTextWriter(httpContext.Response.Output));
                    view.Dispose();
                }
            }
        }

        protected virtual void HandleUiEvents(HttpContext httpContext, IDependencyContainer dependencyContainer, NavigationCollection navigations)
        {
            IControllerRegistry registry = dependencyContainer.Resolve<IControllerRegistry>();
            IModelBinder modelBinder = dependencyContainer.Resolve<IModelBinder>();
            ViewDataCollection viewData = new ViewDataCollection();

            foreach (string key in httpContext.Request.Form.AllKeys)
            {
                IController handler;
                if (registry.TryGet(key, out handler))
                    handler.Execute(new ControllerContext(key, viewData, modelBinder, navigations));
            }

        }

        protected virtual bool ProcessNavigationRules(NavigationCollection navigations, GlobalNavigationCollection globalNavigations, INavigator navigator)
        {
            foreach (string name in navigations)
            {
                FormUri to;
                if (globalNavigations.TryGetValue(name, out to))
                {
                    navigator.Open(to);
                    return true;
                }
            }
            return false;
        }

        protected virtual ExtendedComponentManager GetComponentManager(HttpContext httpContext)
        {
            return new ExtendedComponentManager();
        }

        protected abstract BaseGeneratedView GetCurrentView(HttpContext context);

        protected abstract IDependencyContainer GetDependencyContainer();
    }
}

using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controllers;
using Neptuo.TemplateEngine.Web.Controllers.Binders;
using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

        public void ProcessRequest(HttpContext context)
        {
            Guard.NotNull(context, "context");

            IDependencyContainer container = GetDependencyContainer().CreateChildContainer();
            if (!HandleUiEvents(context, container) && context.Request.Headers[EngineRequestType] != EngineRequestTypePartial)
            {
                BaseGeneratedView view = GetCurrentView();
                ExtendedComponentManager componentManager = GetComponentManager(context);

                container.RegisterInstance<IComponentManager>(componentManager);
                container.RegisterInstance<IPartialUpdateWriter>(componentManager);

                view.Setup(new BaseViewPage(componentManager), componentManager, container);
                view.CreateControls();
                view.Init();
                view.Render(new ExtendedHtmlTextWriter(context.Response.Output));
                view.Dispose();
            }
        }

        protected virtual bool HandleUiEvents(HttpContext httpContext, IDependencyContainer dependencyContainer)
        {
            IControllerRegistry registry = dependencyContainer.Resolve<IControllerRegistry>();
            IModelBinder modelBinder = dependencyContainer.Resolve<IModelBinder>();
            ViewDataCollection viewData = new ViewDataCollection();
            NavigationCollection navigations = dependencyContainer.Resolve<NavigationCollection>();

            foreach (string key in httpContext.Request.Form.AllKeys)
            {
                IController handler;
                if (registry.TryGet(key, out handler))
                    handler.Execute(new ControllerContext(key, viewData, modelBinder, navigations));
            }

            GlobalNavigationCollection globalNavigations = dependencyContainer.Resolve<GlobalNavigationCollection>();
            INavigator navigator = dependencyContainer.Resolve<INavigator>();

            return ProcessNavigationRules(navigations, globalNavigations, navigator);
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

        protected abstract BaseGeneratedView GetCurrentView();

        protected abstract IDependencyContainer GetDependencyContainer();
    }
}

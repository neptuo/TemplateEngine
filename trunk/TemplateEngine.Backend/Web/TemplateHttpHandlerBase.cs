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

namespace Neptuo.TemplateEngine.Backend.Web
{
    public abstract class TemplateHttpHandlerBase : IHttpHandler
    {
        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            IViewServiceContext viewServiceContext = GetViewServiceContext();
            IDependencyContainer container = viewServiceContext.DependencyProvider.CreateChildContainer();

            if (!HandleUiEvents(context, container))
            {
                BaseGeneratedView view = (BaseGeneratedView)GetViewService().Process(GetTemplateUrl(), viewServiceContext);
                IComponentManager componentManager = GetComponentManager(viewServiceContext, context);

                container.RegisterInstance<IComponentManager>(componentManager);

                view.Setup(new BaseViewPage(componentManager), componentManager, container);
                view.CreateControls();
                view.Init();
                view.Render(new HtmlTextWriter(context.Response.Output));
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

        protected virtual IComponentManager GetComponentManager(IViewServiceContext viewServiceContext, HttpContext httpContext)
        {
            return new ComponentManager();
        }

        protected abstract string GetTemplateUrl();

        protected abstract IViewService GetViewService();

        protected abstract IViewServiceContext GetViewServiceContext();
    }
}

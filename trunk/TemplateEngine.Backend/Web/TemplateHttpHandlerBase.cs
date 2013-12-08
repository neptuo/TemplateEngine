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

            HandleUiEvents(context, container);

            BaseGeneratedView view = (BaseGeneratedView)GetViewService().Process(GetTemplateUrl(), viewServiceContext);
            IComponentManager componentManager = GetComponentManager(viewServiceContext, context);

            container.RegisterInstance<IComponentManager>(componentManager);

            view.Setup(new BaseViewPage(componentManager), componentManager, container);
            view.CreateControls();
            view.Init();
            view.Render(new HtmlTextWriter(context.Response.Output));
            view.Dispose();
        }

        protected virtual void HandleUiEvents(HttpContext httpContext, IDependencyContainer dependencyContainer)
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

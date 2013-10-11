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
            BaseGeneratedView view = (BaseGeneratedView)GetViewService().Process(GetTemplateUrl(), viewServiceContext);
            IComponentManager componentManager = GetComponentManager(viewServiceContext, context);

            IDependencyContainer container = viewServiceContext.DependencyProvider.CreateChildContainer();
            container.RegisterInstance<IComponentManager>(componentManager);

            view.Setup(new BaseViewPage(componentManager), componentManager, container);
            view.CreateControls();
            view.Init();
            view.Render(new HtmlTextWriter(context.Response.Output));
            view.Dispose();
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

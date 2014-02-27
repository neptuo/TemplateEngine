using Neptuo.TemplateEngine.Web;
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
    public class TemplateHttpHandler : TemplateHttpHandlerBase
    {
        public string TemplateUrl { get; private set; }
        public IViewService ViewService { get; private set; }
        public IViewServiceContext ViewServiceContext { get; private set; }

        public TemplateHttpHandler(string templateUrl, IViewService viewService, IViewServiceContext viewServiceContext)
        {
            Guard.NotNullOrEmpty(templateUrl, "templateUrl");
            Guard.NotNull(viewService, "viewService");
            Guard.NotNull(viewServiceContext, "viewServiceContext");
            TemplateUrl = templateUrl;
            ViewService = viewService;
            ViewServiceContext = viewServiceContext;
        }

        //protected override IComponentManager GetComponentManager(IViewServiceContext viewServiceContext, HttpContext httpContext)
        //{
        //    return new RequestComponentManager(httpContext.Request.Form);
        //}

        protected override BaseGeneratedView GetCurrentView()
        {
            return (BaseGeneratedView)ViewService.Process(TemplateUrl, ViewServiceContext);
        }

        protected override IDependencyContainer GetDependencyContainer()
        {
            return ViewServiceContext.DependencyProvider.CreateChildContainer();
        }
    }
}

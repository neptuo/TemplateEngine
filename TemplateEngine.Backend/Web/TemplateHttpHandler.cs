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
            TemplateUrl = templateUrl;
            ViewService = viewService;
            ViewServiceContext = viewServiceContext;
        }

        protected override string GetTemplateUrl()
        {
            return TemplateUrl;
        }

        protected override IViewService GetViewService()
        {
            return ViewService;
        }

        protected override IViewServiceContext GetViewServiceContext()
        {
            return ViewServiceContext;
        }

        //protected override IComponentManager GetComponentManager(IViewServiceContext viewServiceContext, HttpContext httpContext)
        //{
        //    return new RequestComponentManager(httpContext.Request.Form);
        //}
    }
}

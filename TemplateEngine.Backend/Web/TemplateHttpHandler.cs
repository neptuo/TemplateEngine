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
        public bool IsReusable
        {
            get { return false; }
        }

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
    }
}

using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Neptuo.TemplateEngine.Backend.Web.Routing
{
    public class StaticTemplateRouteHandler : TemplateRouteHandler
    {
        public string TemplateUrl { get; private set; }

        public StaticTemplateRouteHandler(IViewService viewService, IDependencyProvider dependencyProvider, string templateUrl)
            : base(viewService, dependencyProvider)
        {
            Guard.NotNullOrEmpty(templateUrl, "templateUrl");
            TemplateUrl = templateUrl;
        }

        protected override string GetTemplateUrl(RequestContext requestContext)
        {
            return TemplateUrl;
        }
    }
}

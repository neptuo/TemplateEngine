using Neptuo.TemplateEngine.Backend.Web;
using Neptuo.TemplateEngine.Web.Compilation;
using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace Neptuo.TemplateEngine.Backend.Web.Routing
{
    public class ViewGeneratorRouteHandler : IRouteHandler
    {
        private IJavascriptSourceViewService viewService;
        private IDependencyProvider dependencyProvider;

        public ViewGeneratorRouteHandler(IJavascriptSourceViewService viewService, IDependencyProvider dependencyProvider)
        {
            this.viewService = viewService;
            this.dependencyProvider = dependencyProvider;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new ViewGeneratorHttpHandler(viewService, dependencyProvider);
        }
    }
}

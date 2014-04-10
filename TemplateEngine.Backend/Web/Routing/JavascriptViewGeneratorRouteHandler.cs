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
    public class JavascriptViewGeneratorRouteHandler : IRouteHandler
    {
        private JavascriptViewGeneratorConfiguration configuration;
        private ViewService viewService;
        private IDependencyProvider dependencyProvider;

        public JavascriptViewGeneratorRouteHandler(JavascriptViewGeneratorConfiguration configuration, ViewService viewService, IDependencyProvider dependencyProvider)
        {
            this.configuration = configuration;
            this.viewService = viewService;
            this.dependencyProvider = dependencyProvider;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new JavascriptViewGeneratorHttpHandler(configuration, viewService, dependencyProvider);
        }
    }
}

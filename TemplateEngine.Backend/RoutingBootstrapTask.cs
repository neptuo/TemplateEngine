using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Backend.Web.Routing;
using Neptuo.Templates.Compilation;
using Neptuo.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Neptuo.TemplateEngine.Backend
{
    public class RoutingBootstrapTask : IBootstrapTask
    {
        private RouteCollection routes;
        private IViewService viewService;
        private IDependencyProvider dependencyProvider;

        public RoutingBootstrapTask(IViewService viewService, IDependencyProvider dependencyProvider)
        {
            this.routes = RouteTable.Routes;
            this.viewService = viewService;
            this.dependencyProvider = dependencyProvider;
        }

        public void Initialize()
        {
            RouteParameters.Registry.Add("path", new TemplateRouteParameterFactory());

            routes.Add(new TokenRoute("~/{Path}", new TemplateRouteHandler(viewService, dependencyProvider), TemplateRouteParameter.TemplateUrlSuffix));
            routes.Add(new TokenRoute("~/error", new ErrorRouteHandler(), ".ashx"));
        }
    }
}

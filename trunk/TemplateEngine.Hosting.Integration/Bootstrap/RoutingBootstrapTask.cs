using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Templates.Compilation;
using Neptuo.Templates.Compilation;
using Neptuo.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using Neptuo.TemplateEngine.Hosting.Integration.Routing;
using System.Configuration;

namespace Neptuo.TemplateEngine.Hosting.Integration.Bootstrap
{
    /// <summary>
    /// Registers routes.
    /// </summary>
    public class RoutingBootstrapTask : IBootstrapTask
    {
        private RouteCollection routes;
        private IViewService viewService;
        private ViewService javascriptViewService;
        private IDependencyProvider dependencyProvider;
        private IRouteParameterRegistry routeParameterRegistry;

        public RoutingBootstrapTask(IViewService viewService, ViewService javascriptViewService, IDependencyProvider dependencyProvider)
        {
            this.routes = RouteTable.Routes;
            this.viewService = viewService;
            this.javascriptViewService = javascriptViewService;
            this.dependencyProvider = dependencyProvider;
            this.routeParameterRegistry = RouteParameters.Registry;
        }

        public void Initialize()
        {
            var configuration = new ViewBundleHttpHandlerConfiguration("~/Views", ConfigurationManager.AppSettings["JavascriptTempDirectory"] ?? @"C:\Temp\NeptuoTemplateEngineJavascript");

            routeParameterRegistry.Add("path", new TemplateRouteParameterFactory());

            // Template routes.
            routes.Add(new TokenRoute("~/", new StaticTemplateRouteHandler(viewService, dependencyProvider, "~/Views/Default.view")));
            routes.Add(new TokenRoute("~/{Path}", new TemplateRouteHandler(viewService, dependencyProvider), TemplateRouteParameter.TemplateUrlSuffix));
            
            // Error handler.
            routes.Add(new TokenRoute("~/error", new ErrorRouteHandler(), ".ashx"));
            
            // View bundle and web data source handlers.
            routes.Add(new TokenRoute("~/views", new ViewBundleRouteHandler(configuration, javascriptViewService, dependencyProvider), ".ashx"));
            routes.Add(new TokenRoute("~/DataSource", new DependencyRouteHandler<WebDataSourceHttpHandler>(dependencyProvider), ".ashx"));
        }
    }
}

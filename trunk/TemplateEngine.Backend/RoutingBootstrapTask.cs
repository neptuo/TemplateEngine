﻿using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Backend.Web;
using Neptuo.TemplateEngine.Backend.Web.Routing;
using Neptuo.TemplateEngine.Web.Compilation;
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
        private IJavascriptSourceViewService javascriptViewService;
        private IDependencyProvider dependencyProvider;

        public RoutingBootstrapTask(IViewService viewService, IJavascriptSourceViewService javascriptViewService, IDependencyProvider dependencyProvider)
        {
            this.routes = RouteTable.Routes;
            this.viewService = viewService;
            this.javascriptViewService = javascriptViewService;
            this.dependencyProvider = dependencyProvider;
        }

        public void Initialize()
        {
            var configuration = new JavascriptViewGeneratorConfiguration("~/Views", @"C:\Temp\NeptuoTemplateEngineJavascript");

            RouteParameters.Registry.Add("path", new TemplateRouteParameterFactory());

            routes.Add(new TokenRoute("~/{Path}", new TemplateRouteHandler(viewService, dependencyProvider), TemplateRouteParameter.TemplateUrlSuffix));
            routes.Add(new TokenRoute("~/error", new ErrorRouteHandler(), ".ashx"));
            routes.Add(new TokenRoute("~/views", new JavascriptViewGeneratorRouteHandler(configuration, javascriptViewService, dependencyProvider), ".ashx"));
        }
    }
}
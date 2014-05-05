﻿using Neptuo.TemplateEngine.Hosting.Integration;
using Neptuo.TemplateEngine.Templates.Compilation;
using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace Neptuo.TemplateEngine.Hosting.Integration.Routing
{
    public class JavascriptViewGeneratorRouteHandler : IRouteHandler
    {
        private ViewBundleHttpHandlerConfiguration configuration;
        private ViewService viewService;
        private IDependencyProvider dependencyProvider;

        public JavascriptViewGeneratorRouteHandler(ViewBundleHttpHandlerConfiguration configuration, ViewService viewService, IDependencyProvider dependencyProvider)
        {
            this.configuration = configuration;
            this.viewService = viewService;
            this.dependencyProvider = dependencyProvider;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new ViewBundleHttpHandler(configuration, viewService, dependencyProvider);
        }
    }
}

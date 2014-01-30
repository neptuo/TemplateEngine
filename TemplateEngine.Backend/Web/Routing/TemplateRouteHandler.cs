﻿using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace Neptuo.TemplateEngine.Backend.Web.Routing
{
    public class TemplateRouteHandler : IRouteHandler
    {
        private IViewService viewService;
        private IDependencyProvider dependencyProvider;

        public TemplateRouteHandler(IViewService viewService, IDependencyProvider dependencyProvider)
        {
            this.viewService = viewService;
            this.dependencyProvider = dependencyProvider;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            if (!requestContext.RouteData.Values.ContainsKey("TemplateUrl"))
                throw new InvalidOperationException("Route values must contain 'TemplateUrl' to use TemplateRouteHandler.");

            string templateUrl = requestContext.RouteData.Values["TemplateUrl"] as string;
            if (templateUrl == null)
                throw new InvalidOperationException("TemplateUrl can't be null (and must be of string type).");

            return new TemplateHttpHandler(templateUrl, viewService, new ViewServiceContext(dependencyProvider));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public class RouteData
    {
        public RequestContext Request { get; protected set; }
        public IRouteHandler RouteHandler { get; protected set; }
        public RouteValueDictionary RouteValues { get; protected set; }

        public RouteData(RequestContext request, IRouteHandler routeHandler, RouteValueDictionary routeValues)
        {
            Guard.NotNull(request, "request");
            Guard.NotNull(routeHandler, "routeHandler");
            Guard.NotNull(routeValues, "routeValues");
            Request = request;
            RouteHandler = routeHandler;
            RouteValues = routeValues;
        }
    }
}

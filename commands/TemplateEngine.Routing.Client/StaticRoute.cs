using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    /// <summary>
    /// Static url route.
    /// </summary>
    public class StaticRoute : IRoute
    {
        public string Url { get; private set; }
        public IRouteHandler RouteHandler { get; private set; }

        public StaticRoute(string url, IRouteHandler routeHandler)
        {
            Guard.NotNull(url, "url");
            Guard.NotNull(routeHandler, "routeHandler");
            Url = url;
            RouteHandler = routeHandler;
        }

        public RouteData GetRouteData(RequestContext context)
        {
            if (Url == context.Url)
                return new RouteData(context, RouteHandler, new RouteValueDictionary());

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public class Router : IRouter
    {
        protected List<IRoute> Routes { get; private set; }

        public Router()
        {
            Routes = new List<IRoute>();
        }

        public void AddRoute(IRoute route)
        {
            Guard.NotNull(route, "route");
            Routes.Add(route);
        }

        public void RouteTo(RequestContext context)
        {
            foreach (IRoute route in Routes)
            {
                RouteData routeData = route.GetRouteData(context);
                if (routeData != null)
                {
                    routeData.RouteHandler.ProcessRequest(new RouteContext(routeData));
                    return;
                }
            }

            WhenNoRouteFound(context);
        }

        protected virtual void WhenNoRouteFound(RequestContext context)
        {
            throw new RouteNotFoundException(context);
        }
    }
}

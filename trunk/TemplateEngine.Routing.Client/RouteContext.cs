using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    /// <summary>
    /// Context of route handler execution.
    /// </summary>
    public class RouteContext
    {
        /// <summary>
        /// Request context.
        /// </summary>
        public RequestContext Request { get; protected set; }

        /// <summary>
        /// Route data returned by route.
        /// </summary>
        public RouteData RouteData { get; protected set; }

        /// <summary>
        /// Create new context.
        /// </summary>
        /// <param name="routeData">Route data returned by route.</param>
        public RouteContext(RouteData routeData)
        {
            Guard.NotNull(routeData, "routeData");
            Request = routeData.Request;
            RouteData = routeData;
        }
    }
}

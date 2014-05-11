using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    /// <summary>
    /// <see cref="IRoute"/> outcome.
    /// </summary>
    public class RouteData
    {
        /// <summary>
        /// Request context.
        /// </summary>
        public RequestContext Request { get; protected set; }

        /// <summary>
        /// Handler to execute.
        /// </summary>
        public IRouteHandler RouteHandler { get; protected set; }

        /// <summary>
        /// Custom route values.
        /// </summary>
        public RouteValueDictionary RouteValues { get; protected set; }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="request">Request context.</param>
        /// <param name="routeHandler">Handler to execute.</param>
        /// <param name="routeValues">Custom route values.</param>
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

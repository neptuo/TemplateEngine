using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    /// <summary>
    /// Exception thrown by <see cref="Router"/> when no route is matching <see cref="RequestContext"/>.
    /// </summary>
    public class RouteNotFoundException : Exception
    {
        /// <summary>
        /// Current request context.
        /// </summary>
        public RequestContext RequestContext { get; private set; }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="requestContext">Current request context.</param>
        public RouteNotFoundException(RequestContext requestContext)
        {
            Guard.NotNull(requestContext, "requestContext");
            RequestContext = requestContext;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    /// <summary>
    /// Contains list of routes enables their execution.
    /// </summary>
    public interface IRouter
    {
        /// <summary>
        /// Adds new route.
        /// </summary>
        /// <param name="route">New route.</param>
        void AddRoute(IRoute route);

        /// <summary>
        /// Tries to route <paramref name="context"/> to any of existing routes.
        /// </summary>
        /// <param name="context">Request context.</param>
        void RouteTo(RequestContext context);
    }
}

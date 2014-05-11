using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    /// <summary>
    /// Single route.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// If <paramref name="context"/> meets route restrictions, retuns <see cref="RouteData"/>.
        /// Otherwise retuns null.
        /// </summary>
        /// <param name="context">Request context.</param>
        /// <returns>Route data if route restriction has been met.</returns>
        RouteData GetRouteData(RequestContext context);
    }
}

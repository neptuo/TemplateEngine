using SharpKit.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    /// <summary>
    /// Extends <see cref="Router"/> and uses flag <see cref="RedirectWhenNoRoute"/> for unknown route urls.
    /// </summary>
    public class ApplicationRouter : Router
    {
        /// <summary>
        /// If true, router creates standart get request for unknown route url.
        /// Otherwise creates alert (for debugging).
        /// </summary>
        public bool RedirectWhenNoRoute { get; private set; }

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="redirectWhenNoRoute">
        /// If true, router creates standart get request for unknown route url.
        /// Otherwise creates alert (for debugging).
        /// </param>
        public ApplicationRouter(bool redirectWhenNoRoute)
        {
            RedirectWhenNoRoute = redirectWhenNoRoute;
        }

        /// <summary>
        /// Uses <see cref="RedirectWhenNoRoute"/> to take action when unknown rote url.
        /// </summary>
        /// <param name="context">Request context.</param>
        protected override void WhenNoRouteFound(RequestContext context)
        {
            if (RedirectWhenNoRoute)
                HtmlContext.window.location.href = context.Url;
            else
                HtmlContext.alert("Route not found for: " + context.Url);
        }
    }
}

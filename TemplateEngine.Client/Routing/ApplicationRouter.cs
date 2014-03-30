using SharpKit.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public class ApplicationRouter : Router
    {
        public bool RedirectWhenNoRoute { get; private set; }

        public ApplicationRouter(bool redirectWhenNoRoute)
        {
            RedirectWhenNoRoute = redirectWhenNoRoute;
        }

        protected override void WhenNoRouteFound(RequestContext context)
        {
            if (RedirectWhenNoRoute)
                HtmlContext.window.location.href = context.Url;
            else
                HtmlContext.alert("Route not found for: " + context.Url);
        }
    }
}

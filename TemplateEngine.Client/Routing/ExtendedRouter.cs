using SharpKit.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public class ExtendedRouter : Router
    {
        protected override void WhenNoRouteFound(RequestContext context)
        {
            HtmlContext.alert("Route not found for: " + context.Url);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public interface IRoute
    {
        RouteData GetRouteData(RequestContext context);
    }
}

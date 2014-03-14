using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public class RouteContext
    {
        public RequestContext Request { get; protected set; }
        public RouteData RouteData { get; protected set; }

        public RouteContext(RouteData routeData)
        {
            Guard.NotNull(routeData, "routeData");
            Request = routeData.Request;
            RouteData = routeData;
        }
    }
}

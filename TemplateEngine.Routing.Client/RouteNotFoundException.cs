using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public class RouteNotFoundException : Exception
    {
        public RequestContext RequestContext { get; private set; }

        public RouteNotFoundException(RequestContext requestContext)
        {
            Guard.NotNull(requestContext, "requestContext");
            RequestContext = requestContext;
        }
    }
}

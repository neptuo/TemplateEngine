using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace Neptuo.TemplateEngine.Hosting.Integration.Routing
{
    /// <summary>
    /// Error route handler.
    /// </summary>
    public class ErrorRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new ErrorHttpHandler();
        }
    }
}

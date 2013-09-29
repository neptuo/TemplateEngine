using Neptuo.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Backend.Web.Routing
{
    public class TemplateRouteParameterFactory : IRouteParameterFactory
    {
        public IRouteParameter CreateParameter(HttpContextBase httpContext)
        {
            return new TemplateRouteParameter(httpContext);
        }
    }

}

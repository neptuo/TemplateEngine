using Neptuo.Collections.Generic;
using Neptuo.TemplateEngine.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class RouteParameterProvider : DictionaryParameterProvider
    {
        private RouteContext routeContext;

        public RouteParameterProvider(RouteContext routeContext)
            : base(new Dictionary<string, string>())
        {
            Guard.NotNull(routeContext, "routeContext");
            Parameters.AddRange(routeContext.Request.Form);
            Parameters.AddRange(routeContext.Request.QueryString);
        }
    }
}

using Neptuo.Collections.Generic;
using Neptuo.TemplateEngine.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{

    public class RouteParameterProviderFactory : IParameterProviderFactory
    {
        private RouteContext routeContext;

        public RouteParameterProviderFactory(RouteContext routeContext)
        {
            Guard.NotNull(routeContext, "routeContext");
            this.routeContext = routeContext;
        }

        public IParameterProvider Provider(ParameterProviderType providerType)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            switch (providerType)
            {
                case ParameterProviderType.All:
                    parameters.AddRange(routeContext.Request.Form);
                    parameters.AddRange(routeContext.Request.QueryString);
                    break;
                case ParameterProviderType.Url:
                    parameters.AddRange(routeContext.Request.QueryString);
                    break;
                case ParameterProviderType.Form:
                    parameters.AddRange(routeContext.Request.Form);
                    break;
                default:
                    break;
            }
            return new DictionaryParameterProvider(parameters);
        }
    }
}

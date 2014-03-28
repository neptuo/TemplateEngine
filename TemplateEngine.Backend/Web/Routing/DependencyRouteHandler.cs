using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace Neptuo.TemplateEngine.Backend.Web.Routing
{
    public class DependencyRouteHandler<T> : IRouteHandler
        where T : IHttpHandler
    {
        protected IDependencyProvider DependencyProvider { get; private set; }

        public DependencyRouteHandler(IDependencyProvider dependencyProvider)
        {
            Guard.NotNull(dependencyProvider, "dependencyProvider");
            DependencyProvider = dependencyProvider;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return DependencyProvider.Resolve<T>();
        }
    }
}

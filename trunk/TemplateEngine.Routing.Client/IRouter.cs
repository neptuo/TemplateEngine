using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public interface IRouter
    {
        void AddRoute(IRoute route);
        void RouteTo(RequestContext context);
    }
}

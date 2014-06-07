using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    /// <summary>
    /// Route executor.
    /// </summary>
    public interface IRouteHandler
    {
        /// <summary>
        /// Executes request with <paramref name="context"/>.
        /// </summary>
        /// <param name="context">Execution context.</param>
        void ProcessRequest(RouteContext context);
    }
}

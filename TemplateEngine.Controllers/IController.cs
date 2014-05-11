using Neptuo.TemplateEngine.Providers.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    /// <summary>
    /// Contract for controller.
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Executes controller with <paramref name="context"/>.
        /// </summary>
        /// <param name="context">Controller context.</param>
        void Execute(IControllerContext context);
    }
}

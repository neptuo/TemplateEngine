using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    /// <summary>
    /// Registry for controllers.
    /// </summary>
    public interface IControllerRegistry
    {
        /// <summary>
        /// Adds new controller factory for action <paramref name="actionName"/>.
        /// </summary>
        /// <param name="actionName">Action name to map <paramref name="factory"/> to.</param>
        /// <param name="factory">Controler factory.</param>
        /// <returns></returns>
        IControllerRegistry Add(string actionName, IControllerFactory factory);

        /// <summary>
        /// Tries to find controller for <paramref name="actionName"/>.
        /// </summary>
        /// <param name="actionName">Action name.</param>
        /// <param name="controller">Controller if one exists for <paramref name="actionName"/>.</param>
        /// <returns>True if there is registered controller for <paramref name="actionName"/>.</returns>
        bool TryGet(string actionName, out IController controller);
    }
}

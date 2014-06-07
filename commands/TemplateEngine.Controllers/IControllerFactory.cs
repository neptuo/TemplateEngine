using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    /// <summary>
    /// Factory for <see cref="IController"/>.
    /// </summary>
    public interface IControllerFactory
    {
        /// <summary>
        /// Creates instance of <see cref="IController"/>.
        /// </summary>
        /// <returns>Creates instance of <see cref="IController"/>.</returns>
        IController Create();
    }
}

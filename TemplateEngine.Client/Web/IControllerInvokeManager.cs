using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Manages <see cref="IControllerInvoker"/>.
    /// </summary>
    public interface IControllerInvokeManager
    {
        /// <summary>
        /// Starts <paramref name="invoker"/>.
        /// </summary>
        /// <param name="invoker">Invoker to start.</param>
        void Invoke(IControllerInvoker invoker);
    }
}

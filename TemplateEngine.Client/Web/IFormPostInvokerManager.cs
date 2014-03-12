using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Manages <see cref="IFormPostInvoker"/>.
    /// </summary>
    public interface IFormPostInvokerManager
    {
        /// <summary>
        /// Starts <paramref name="invoker"/>.
        /// </summary>
        /// <param name="invoker">Invoker to start.</param>
        void Invoke(IFormPostInvoker invoker);
    }
}

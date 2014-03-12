using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Contract for processing forms usign POST.
    /// </summary>
    public interface IFormPostInvoker
    {
        /// <summary>
        /// Executed when POST is successufull.
        /// </summary>
        event Action<IFormPostInvoker> OnSuccess;

        /// <summary>
        /// Starts POST request.
        /// </summary>
        void Invoke();
    }
}

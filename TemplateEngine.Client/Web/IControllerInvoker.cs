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
    public interface IControllerInvoker
    {
        /// <summary>
        /// Executed when POST is successfull.
        /// </summary>
        event Action<IControllerInvoker> OnSuccess;

        /// <summary>
        /// Executed when POST was not successfull;
        /// </summary>
        event Action<IControllerInvoker, ErrorModel> OnError;

        /// <summary>
        /// Starts POST request.
        /// </summary>
        void Invoke();
    }
}

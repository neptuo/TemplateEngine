using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    /// <summary>
    /// Context of controller execution.
    /// </summary>
    public interface IControllerContext
    {
        /// <summary>
        /// Action name.
        /// </summary>
        string ActionName { get; }

        /// <summary>
        /// Model binder to bind parameters with.
        /// </summary>
        IModelBinder ModelBinder { get; }

        /// <summary>
        /// Current dependency provider.
        /// </summary>
        IDependencyProvider DependencyProvider { get; }

        /// <summary>
        /// Output navigation rule.
        /// </summary>
        string Navigation { get; set; }

        /// <summary>
        /// List of messages.
        /// </summary>
        MessageStorage Messages { get; }
    }

}

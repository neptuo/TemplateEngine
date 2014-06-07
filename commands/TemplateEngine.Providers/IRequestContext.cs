using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Web;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    /// <summary>
    /// Describes current request.
    /// </summary>
    public interface IRequestContext : ICurrentUrlProvider, IVirtualUrlProvider, IParameterProviderFactory
    {
        /// <summary>
        /// Current component manager.
        /// </summary>
        IComponentManager ComponentManager { get; }
    }
}

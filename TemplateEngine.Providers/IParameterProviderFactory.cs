using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    /// <summary>
    /// Factory for <see cref="IParameterProvider"/>.
    /// </summary>
    public interface IParameterProviderFactory
    {
        /// <summary>
        /// Gets parameter provider specifis parameters.
        /// </summary>
        /// <param name="providerType">Type of parameters.</param>
        /// <returns><see cref="IParameterProvider"/>.</returns>
        IParameterProvider Provider(ParameterProviderType providerType);
    }
}

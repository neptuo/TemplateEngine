using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers.ModelBinders
{
    /// <summary>
    /// Parameters->model binder.
    /// </summary>
    public interface IModelBinder
    {
        /// <summary>
        /// Creates instance of <paramref name="targetType"/> and binds parameters.
        /// </summary>
        /// <param name="targetType">Result object type.</param>
        /// <returns>Creates instance of <paramref name="targetType"/> and binds parameters.</returns>
        object Bind(Type targetType);

        /// <summary>
        /// Binds parameters to properties of <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">Any object instance.</param>
        /// <returns><paramref name="instance"/> with bound parameters.</returns>
        object Bind(object instance);
    }
}

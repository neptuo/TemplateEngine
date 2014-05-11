using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    /// <summary>
    /// Binding manager used by <paramref name="BindingExtension"/>.
    /// Processes navigation properties on object and gets/sets value on target objects.
    /// </summary>
    public interface IBindingManager
    {
        /// <summary>
        /// Tries to set navigation property <paramref name="expression"/> on root object <paramref name="target"/>.
        /// New value is in <paramref name="value"/>.
        /// </summary>
        /// <param name="target">Object to apply <paramref name="expression"/> on.</param>
        /// <param name="expression">Navigation property.</param>
        /// <param name="value">New value.</param>
        /// <returns>True if succeeded.</returns>
        bool TrySetValue(object target, string expression, object value);

        /// <summary>
        /// Tries to get value of navigation property <paramref name="expression"/> on root object <paramref name="target"/>.
        /// </summary>
        /// <param name="target">Object to apply <paramref name="expression"/> on.</param>
        /// <param name="expression">Navigation property.</param>
        /// <param name="value">Property value.</param>
        /// <returns>True if succeeded.</returns>
        bool TryGetValue(string expression, object source, out object value);
    }
}

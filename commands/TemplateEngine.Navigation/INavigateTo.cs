using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    /// <summary>
    /// Represents opened navigation.
    /// Calling to <see cref="Open"/> executes navigation.
    /// </summary>
    public interface INavigateTo
    {
        /// <summary>
        /// Sets parameter to current navigation context.
        /// </summary>
        /// <param name="key">Parameter key.</param>
        /// <param name="value">Parameter value.</param>
        void Param(string key, object value);

        /// <summary>
        /// Executes navigation.
        /// No parameters can be than set.
        /// </summary>
        void Open();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    /// <summary>
    /// Provides access to current parameters.
    /// </summary>
    public interface IParameterProvider
    {
        /// <summary>
        /// All parameter keys.
        /// </summary>
        IEnumerable<string> Keys { get; }

        /// <summary>
        /// Tries get value of parameter <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        /// <returns>True if parameter exists.</returns>
        bool TryGet(string key, out object value);
    }
}

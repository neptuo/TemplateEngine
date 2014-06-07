using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    /// <summary>
    /// Provides current request url.
    /// </summary>
    public interface ICurrentUrlProvider
    {
        /// <summary>
        /// Provides current request url.
        /// </summary>
        /// <returns>Current request url.</returns>
        string GetCurrentUrl();
    }
}

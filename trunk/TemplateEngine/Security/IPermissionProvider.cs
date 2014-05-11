using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    /// <summary>
    /// Provides permission settings.
    /// </summary>
    public interface IPermissionProvider
    {
        /// <summary>
        /// Returns whether <paramref name="action"/> is granted on <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Target object.</param>
        /// <param name="action">Action wanted to test on <paramref name="key"/>.</param>
        /// <returns>True if <paramref name="action"/> is granted on <paramref name="key"/>.</returns>
        bool IsAllowed(object key, string action);

        /// <summary>
        /// Gets set of permission settings for <paramref name="key"/>.
        /// </summary>
        /// <param name="key">Target object.</param>
        /// <returns>Set of permission settings for <paramref name="key"/>.</returns>
        IPermissionSet Get(object key);
    }
}

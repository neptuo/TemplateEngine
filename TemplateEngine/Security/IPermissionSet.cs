using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    /// <summary>
    /// Contains permission settings for single object, <see cref="IPermissionProvider.Get"/>.
    /// </summary>
    public interface IPermissionSet
    {
        /// <summary>
        /// Returns whether <paramref name="action"/> is granted.
        /// </summary>
        /// <param name="action">Action wanted to test on <paramref name="key"/>.</param>
        /// <returns>True if <paramref name="action"/> is granted.</returns>
        bool IsAllowed(string action);
    }
}

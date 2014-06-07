using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    /// <summary>
    /// Implementation of <see cref="IPermissionSet"/> that gets list of granted permissions and operate on it.
    /// </summary>
    public class PermissionSet : IPermissionSet
    {
        /// <summary>
        /// List of granted permissions.
        /// </summary>
        private IEnumerable<string> availablePermissions;

        /// <summary>
        /// Create new instance.
        /// </summary>
        /// <param name="availablePermissions">List of granted permissions.</param>
        public PermissionSet(IEnumerable<string> availablePermissions)
        {
            Guard.NotNull(availablePermissions, "availablePermissions");
            this.availablePermissions = availablePermissions;
        }

        /// <summary>
        /// Returns true if <see cref="availablePermissions"/> contains <paramref name="action"/>.
        /// </summary>
        /// <param name="action">Action wanted to test on <paramref name="key"/>.</param>
        /// <returns>True if <see cref="availablePermissions"/> contains <paramref name="action"/>.</returns>
        public bool IsAllowed(string action)
        {
            return availablePermissions.Contains(action);
        }
    }
}

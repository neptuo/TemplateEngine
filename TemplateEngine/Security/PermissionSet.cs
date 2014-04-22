using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    public class PermissionSet : IPermissionSet
    {
        private IEnumerable<string> availablePermissions;

        public PermissionSet(IEnumerable<string> availablePermissions)
        {
            Guard.NotNull(availablePermissions, "availablePermissions");
            this.availablePermissions = availablePermissions;
        }

        public bool IsAllowed(string action)
        {
            return availablePermissions.Contains(action);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    /// <summary>
    /// Provides access to all objects with all actions.
    /// Testing implementation.
    /// </summary>
    public class OptimisticPermissionProvider : IPermissionProvider
    {
        public bool IsAllowed(object key, string action)
        {
            return true;
        }

        public IPermissionSet Get(object key)
        {
            return new OptimisticPermissionSet();
        }
    }
}

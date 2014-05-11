using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    /// <summary>
    /// Provides access to all actions.
    /// Testing implementation.
    /// </summary>
    public class OptimisticPermissionSet : IPermissionSet
    {
        public bool IsAllowed(string action)
        {
            return true;
        }
    }
}

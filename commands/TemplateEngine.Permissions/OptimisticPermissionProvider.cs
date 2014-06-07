using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Permissions
{
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Permissions
{
    public class OptimisticPermissionSet : IPermissionSet
    {
        public bool IsAllowed(string action)
        {
            return true;
        }
    }
}

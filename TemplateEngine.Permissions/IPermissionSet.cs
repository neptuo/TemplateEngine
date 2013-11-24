using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Permissions
{
    public interface IPermissionSet
    {
        bool IsAllowed(string action);
    }
}

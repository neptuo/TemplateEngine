using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    public interface IPermissionProvider
    {
        bool IsAllowed(object key, string action);
        IPermissionSet Get(object key);
    }
}

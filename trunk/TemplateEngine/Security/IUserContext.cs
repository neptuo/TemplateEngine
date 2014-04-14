using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    public interface IUserContext
    {
        IUserInfo User { get; }
        IPermissionProvider Permissions { get; }
        bool IsAuthenticated { get; }
    }
}

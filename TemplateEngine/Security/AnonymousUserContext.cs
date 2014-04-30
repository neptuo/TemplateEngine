using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    public class AnonymousUserContext : IUserContext
    {
        public IUserInfo User
        {
            get { return null; }
        }

        public IPermissionProvider Permissions
        {
            get { return new OptimisticPermissionProvider(); }
        }

        public string AuthenticationToken
        {
            get { return String.Empty; }
        }

        public bool IsAuthenticated
        {
            get { return false; }
        }
    }
}

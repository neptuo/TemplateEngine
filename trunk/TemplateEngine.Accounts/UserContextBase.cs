using Neptuo.TemplateEngine.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserContextBase : IUserLogContext, IUserContext
    {
        private IPermissionProvider permissionProvider;

        public virtual UserLog Log { get; protected set; }

        public IUserInfo User
        {
            get { return Log.User; }
        }

        public IPermissionProvider Permissions
        {
            get
            {
                if (permissionProvider == null)
                    permissionProvider = GetPermissionProvider();

                return permissionProvider;
            }
        }

        public virtual bool IsAuthenticated { get; protected set; }

        public virtual string AuthenticationToken { get; protected set; }

        public UserContextBase(UserLog log)
        {
            Log = log;
        }

        protected virtual IPermissionProvider GetPermissionProvider()
        {
            throw new NotImplementedException();
        }
    }
}

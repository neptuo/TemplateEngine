using Neptuo.TemplateEngine.Accounts.Data.Queries;
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
        private IActivator<IResourcePermissionQuery> permissionQueryFactory;
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

        public UserContextBase(UserLog log, IActivator<IResourcePermissionQuery> permissionQueryFactory)
        {
            Log = log;
        }

        protected virtual IPermissionProvider GetPermissionProvider()
        {
            return new ResourcePermissionProvider(permissionQueryFactory, Log.User.Roles.Select(r => r.Key));
        }
    }
}

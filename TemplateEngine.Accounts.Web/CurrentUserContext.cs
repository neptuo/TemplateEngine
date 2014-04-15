using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Accounts.Web
{
    public class CurrentUserContext : IUserLogContext, IUserContext
    {
        private readonly HttpContextBase httpContext;
        private readonly UserLogDataProvider userLogs;

        private UserLog userLog;
        private IPermissionProvider permissionProvider;

        public UserLog Log
        {
            get
            {
                if (userLog == null)
                    userLog = GetUserLog();

                return userLog;
            }
        }

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

        public bool IsAuthenticated
        {
            get { return httpContext.User.Identity.IsAuthenticated; }
        }

        public string AuthenticationToken
        {
            get { return httpContext.User.Identity.Name; }
        }

        public CurrentUserContext(HttpContextBase httpContext, UserLogDataProvider userLogs)
        {
            Guard.NotNull(httpContext, "httpContext");
            Guard.NotNull(userLogs, "userLogs");
            this.httpContext = httpContext;
            this.userLogs = userLogs;
        }

        private Guid? GetSessionKey()
        {
            Guid? sessionKey = null;
            Guid parsed;
            if (httpContext.User.Identity.IsAuthenticated)
            {
                if (Guid.TryParse(httpContext.User.Identity.Name, out parsed))
                    sessionKey = parsed;
            }
            else if (httpContext.Request.Headers["X-Auth"] != null && Guid.TryParse(httpContext.Request.Headers["X-Auth"], out parsed))
            {
                sessionKey = parsed;
            }

            return sessionKey;
        }

        private UserLog GetUserLog()
        {
            Guid? sessionKey = GetSessionKey();
            if (sessionKey != null)
            {
                //TODO: Test whether ticket is still active.
                UserLog log = userLogs.Repository.Get(sessionKey.Value);
                //TODO: Test whether ticket is not closed.
                
                log.LastActivity = DateTime.Now;
                userLogs.Repository.Update(log);

                return log;
            }

            //TODO: Throw.
            return null;
        }

        private IPermissionProvider GetPermissionProvider()
        {
            throw new NotImplementedException();
        }
    }
}

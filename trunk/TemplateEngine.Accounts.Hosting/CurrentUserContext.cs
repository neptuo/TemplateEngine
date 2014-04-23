using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Configuration;
using Neptuo.TemplateEngine.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Accounts.Hosting
{
    public class CurrentUserContext : UserContextBase
    {
        private readonly HttpContextBase httpContext;
        private readonly UserLogDataProvider userLogs;

        private UserLog userLog;

        public override UserLog Log
        {
            get
            {
                if (userLog == null)
                    userLog = GetUserLog();

                return userLog;
            }
            protected set { userLog = value; }
        }

        public CurrentUserContext(IApplicationConfiguration configuration, HttpContextBase httpContext, UserLogDataProvider userLogs, IActivator<IResourcePermissionQuery> permissionQueryFactory)
            : base(configuration, null, permissionQueryFactory)
        {
            Guard.NotNull(httpContext, "httpContext");
            Guard.NotNull(userLogs, "userLogs");
            this.httpContext = httpContext;
            this.userLogs = userLogs;

            IsAuthenticated = httpContext.User.Identity.IsAuthenticated;
            AuthenticationToken = httpContext.User.Identity.Name;
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
    }
}

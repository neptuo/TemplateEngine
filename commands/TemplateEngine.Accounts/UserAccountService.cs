using Neptuo.Events;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Accounts.Events;
using Neptuo.TemplateEngine.Configuration;
using Neptuo.TemplateEngine.Security;
using Neptuo.TemplateEngine.Security.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserAccountService : IAuthenticator
    {
        protected IApplicationConfiguration Configuration { get; private set; }
        protected IEventDispatcher EventDispatcher { get; private set; }
        protected IUserRoleRepository UserRoles { get; private set; }
        protected UserAccountDataProvider UserAccounts { get; private set; }
        protected UserLogDataProvider UserLogs { get; private set; }
        protected IActivator<IResourcePermissionQuery> PermissionQueryFactory { get; private set; }
        protected IUserLogContext UserContext { get; private set; }

        public UserAccountService(IApplicationConfiguration configuration, IEventDispatcher eventDispatcher, UserAccountDataProvider userAccounts, UserLogDataProvider userLogs, IActivator<IResourcePermissionQuery> permissionQueryFactory, IUserRoleRepository userRoles, IUserLogContext userContext)
        {
            Configuration = configuration;
            EventDispatcher = eventDispatcher;
            UserAccounts = userAccounts;
            UserLogs = userLogs;
            UserRoles = userRoles;
            PermissionQueryFactory = permissionQueryFactory;
            UserContext = userContext;
        }

        public UserAccount Get(int userKey)
        {
            return UserAccounts.Repository.Get(userKey);
        }

        public UserAccount CreateAccount(string username, string password, bool enabled)
        {
            UserAccount userAccount = UserAccounts.Factory.Create();
            userAccount.Username = username;
            userAccount.Password = PasswordProvider.ComputePassword(username, password);
            userAccount.IsEnabled = enabled;

            UserAccounts.Repository.Insert(userAccount);
            EventDispatcher.Publish(new UserAccountCreated(userAccount.Key, userAccount.Username));
            return userAccount;
        }

        public void DeleteAccount(int userKey)
        {
            EventDispatcher.Publish(new UserAccountDeleted(userKey));
            UserAccounts.Repository.Delete(UserAccounts.Repository.Get(userKey));
        }

        public void AssignAccountToRole(UserAccount account, int userRoleID)
        {
            UserRole userRole = UserRoles.Get(userRoleID);
            if (userRole == null)
                throw new ArgumentOutOfRangeException("userRoleID", String.Format("No such user role, for id '{0}'.", userRoleID));

            if (account.Roles == null)
                account.Roles = new List<UserRole>();

            account.Roles.Add(userRole);
            UserAccounts.Repository.Update(account);
        }

        public bool Login(string username, string password)
        {
            Guard.NotNullOrEmpty(username, "username");
            Guard.NotNullOrEmpty(password, "password");

            var query = UserAccounts.Query();
            query.Filter = new CredentialsAccountFilter(username, password);
            UserAccount account = query.ResultSingle();
            if (account != null)
            {
                UserLog log = UserLogs.Factory.Create();
                log.Key = Guid.NewGuid();
                log.SignedIn = DateTime.Now;
                log.LastActivity = DateTime.Now;
                log.User = account;
                UserLogs.Repository.Insert(log);

                EventDispatcher.Publish(new UserLogCreatedEvent(log));
                EventDispatcher.Publish(new UserSignedInEvent(new UserContextBase(Configuration, log, PermissionQueryFactory, log.Key.ToString()), log.SignedIn));//TODO: Pass new user context
                return true;
            }
            return false;
        }


        public bool Logout()
        {
            return true;
        }
    }
}

using Neptuo.Events;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserAccountService
    {
        protected IEventDispatcher EventDispatcher { get; private set; }
        protected IUserAccountRepository UserAccounts { get; private set; }

        public UserAccountService(IEventDispatcher eventDispatcher, IUserAccountRepository userAccounts)
        {
            EventDispatcher = eventDispatcher;
            UserAccounts = userAccounts;
        }

        public UserAccount CreateAccount(string username, string password, bool enabled)
        {
            UserAccount userAccount = UserAccounts.Create();
            userAccount.Username = username;
            userAccount.Password = password;
            userAccount.IsEnabled = enabled;

            UserAccounts.Insert(userAccount);
            EventDispatcher.Publish(new UserAccountCreated(userAccount.Key, userAccount.Username));
            return userAccount;
        }

        public void DeleteAccount(int userKey)
        {
            UserAccounts.Delete(UserAccounts.Get(userKey));
        }
    }
}

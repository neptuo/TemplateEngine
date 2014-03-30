using Neptuo.Commands.Handlers;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.Controllers
{
    [Action("Accounts/User/Update")]
    [Validate("UserEdit")]
    [Transactional]
    public class UserAccountUpdateHandler : ICommandHandler<UserAccountEditCommand>
    {
        protected IUserAccountRepository UserAccounts { get; private set; }
        protected MessageStorage MessageStorage { get; private set; }
        protected UserAccountService AccountService { get; private set; }
        protected NavigationCollection Navigations { get; private set; }

        public UserAccountUpdateHandler(IUserAccountRepository userAccounts, MessageStorage messageStorage, UserAccountService accountService, NavigationCollection navigations)
        {
            UserAccounts = userAccounts;
            MessageStorage = messageStorage;
            AccountService = accountService;
            Navigations = navigations;
        }

        public void Handle(UserAccountEditCommand model)
        {
            UserAccount account = UserAccounts.Get(model.Key);
            if (account == null)
                throw new NotImplementedException();

            if (account.Username != model.Username)
                account.Username = model.Username;

            if (account.Password != model.Password && !String.IsNullOrEmpty(model.Password))
                account.Password = model.Password;

            if (account.IsEnabled != model.IsEnabled)
                account.IsEnabled = model.IsEnabled;

            if(model.RoleKeys != null)
            {
                account.Roles.Clear();

                foreach (int userRoleID in model.RoleKeys)
                    AccountService.AssignAccountToRole(account, userRoleID);
            }

            UserAccounts.Update(account);

            MessageStorage.Add(null, String.Empty, "User account modified.", MessageType.Info);
            Navigations.Add("Accounts.User.Updated");
        }
    }
}

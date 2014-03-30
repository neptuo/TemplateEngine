using Neptuo.Commands.Handlers;
using Neptuo.Data;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controllers;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.Controllers
{
    [Action("Accounts/User/Create")]
    [Validate("UserEdit")]
    [Transactional]
    public class UserAccountCreateHandler : ICommandHandler<UserAccountCreateCommand>
    {
        protected IUserAccountRepository UserAccounts { get; private set; }
        protected MessageStorage MessageStorage { get; private set; }
        protected UserAccountService AccountService { get; private set; }
        protected NavigationCollection Navigations { get; private set; }

        public UserAccountCreateHandler(IUserAccountRepository userAccounts, MessageStorage messageStorage, UserAccountService accountService, NavigationCollection navigations)
        {
            UserAccounts = userAccounts;
            MessageStorage = messageStorage;
            AccountService = accountService;
            Navigations = navigations;
        }

        public void Handle(UserAccountCreateCommand model)
        {
            UserAccount account = AccountService.CreateAccount(model.Username, model.Password, model.IsEnabled);
            if (model.RoleKeys != null)
            {
                foreach (int userRoleID in model.RoleKeys)
                    AccountService.AssignAccountToRole(account, userRoleID);
            }

            MessageStorage.Add(null, String.Empty, "User account created.", MessageType.Info);
            Navigations.Add("Accounts.User.Created");
        }
    }
}

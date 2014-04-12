using Neptuo.Commands.Handlers;
using Neptuo.Data;
using Neptuo.Events;
using Neptuo.Events.Handlers;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Events;
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
    public class UserAccountCreateHandler : ICommandHandler<UserAccountCreateCommand>, IEventHandler<UserAccountCreated>
    {
        protected IEventManager EventManager { get; private set; }
        protected MessageStorage MessageStorage { get; private set; }
        protected UserAccountService AccountService { get; private set; }
        protected NavigationCollection Navigations { get; private set; }

        private UserAccountCreateCommand model;

        public UserAccountCreateHandler(IEventManager eventManager, MessageStorage messageStorage, UserAccountService accountService, NavigationCollection navigations)
        {
            EventManager = eventManager;
            MessageStorage = messageStorage;
            AccountService = accountService;
            Navigations = navigations;
        }

        public void Handle(UserAccountCreateCommand model)
        {
            this.model = model;
            
            using (EventManager.Using(this))
            {
                UserAccount account = AccountService.CreateAccount(model.Username, model.Password, model.IsEnabled);
            }

            MessageStorage.Add(null, String.Empty, "User account created.", MessageType.Info);
            Navigations.Add("Accounts.User.Created");
        }

        public void Handle(UserAccountCreated eventData)
        {
            UserAccount account = AccountService.Get(eventData.UserKey);
            if (model.RoleKeys != null)
            {
                foreach (int userRoleID in model.RoleKeys)
                    AccountService.AssignAccountToRole(account, userRoleID);
            }
        }
    }
}

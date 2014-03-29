using Neptuo.Commands;
using Neptuo.Data;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controllers;
using Neptuo.TemplateEngine.Web.Controllers.Binders;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.Controllers
{
    public class UserAccountController : ControllerBase
    {
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }
        protected IUserAccountRepository UserAccounts { get; private set; }
        protected ICommandDispatcher CommandDispatcher { get; private set; }
        protected IValidator<UserAccountCreateCommand> CreateValidator { get; private set; }
        protected IValidator<UserAccountEditCommand> EditValidator { get; private set; }
        protected MessageStorage MessageStorage { get; private set; }
        protected UserAccountService AccountService { get; private set; }

        public UserAccountController(IUnitOfWorkFactory unitOfWorkFactory, IUserAccountRepository userAccounts, ICommandDispatcher commandDispatcher, IValidator<UserAccountEditCommand> editValidator, IValidator<UserAccountCreateCommand> createValidator, MessageStorage messageStorage, UserAccountService accountService)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            UserAccounts = userAccounts;
            CommandDispatcher = commandDispatcher;
            EditValidator = editValidator;
            CreateValidator = createValidator;
            MessageStorage = messageStorage;
            AccountService = accountService;
        }

        #region Delete

        [Action("Accounts/User/Delete")]
        public void Delete()
        {
            UserDeleteModel model = Context.ModelBinder.Bind<UserDeleteModel>(new UserDeleteModel());
            if (model.UserKey != 0)
            {
                using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
                {
                    //CommandDispatcher.Handle(new UserAccountDeleteCommand(model.UserKey));
                    AccountService.DeleteAccount(model.UserKey);
                    Context.Navigations.Add("Accounts.User.Deleted");
                    MessageStorage.Add(null, String.Empty, "User account deleted", MessageType.Info);
                    transaction.SaveChanges();
                }
            }
        }

        public class UserDeleteModel
        {
            public int UserKey { get; set; }
        }

        #endregion

        #region Create/Update

        [Action("Accounts/User/Create")]
        public void Create()
        {
            UserAccountCreateCommand model = Context.ModelBinder.Bind<UserAccountCreateCommand>();
            IValidationResult validationResult = CreateValidator.Validate(model);
            if (!validationResult.IsValid)
            {
                MessageStorage.AddValidationResult(validationResult, "UserEdit");
                Context.ViewData.SetUserAccountCreate(model);
                return;
            }

            using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
            {
                //CommandDispatcher.Handle(model);
                UserAccount account = AccountService.CreateAccount(model.Username, model.Password, model.IsEnabled);
                if (model.RoleKeys != null)
                {
                    foreach (int userRoleID in model.RoleKeys)
                        AccountService.AssignAccountToRole(account, userRoleID);
                }

                transaction.SaveChanges();

                MessageStorage.Add(null, String.Empty, "User account created.", MessageType.Info);
                Context.Navigations.Add("Accounts.User.Created");
            }
        }

        [Action("Accounts/User/Update")]
        public void Update()
        {
            UserAccountEditCommand model = Context.ModelBinder.Bind<UserAccountEditCommand>(new UserAccountEditCommand());
            IValidationResult validationResult = EditValidator.Validate(model);
            if (!validationResult.IsValid)
            {
                MessageStorage.AddValidationResult(validationResult, "UserEdit");
                Context.ViewData.SetUserAccountEdit(model);
                return;
            }

            using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
            {
                CommandDispatcher.Handle(model);
                transaction.SaveChanges();

                MessageStorage.Add(null, String.Empty, "User account modified.", MessageType.Info);
                Context.Navigations.Add("Accounts.User.Updated");
            }
        }

        #endregion

        #region Login

        [Action("Accounts/Login")]
        public void Login()
        {
            UserAccountLoginModel model = Context.ModelBinder.Bind<UserAccountLoginModel>();
            bool result = AccountService.Login(model.Username, model.Password);

            if (result)
            {
                MessageStorage.Add(null, String.Empty, "User signed in.", MessageType.Info);
                Context.Navigations.Add("Accounts.LoggedIn");
            }
        }

        #endregion
    }
}

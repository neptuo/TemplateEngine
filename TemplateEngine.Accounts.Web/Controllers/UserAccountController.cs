using Neptuo.Data;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Neptuo.TemplateEngine.Providers;

namespace Neptuo.TemplateEngine.Accounts.Controllers
{
    public class UserAccountController : ControllerBase
    {
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }
        protected IUserAccountRepository UserAccounts { get; private set; }
        protected IValidatorService ValidationService { get; private set; }
        protected UserAccountService AccountService { get; private set; }

        public UserAccountController(IUnitOfWorkFactory unitOfWorkFactory, IUserAccountRepository userAccounts, IValidatorService validationService, UserAccountService accountService)
        {
            UnitOfWorkFactory = unitOfWorkFactory;
            UserAccounts = userAccounts;
            ValidationService = validationService;
            AccountService = accountService;
        }

        #region Delete

        [Action("Accounts/User/Delete")]
        public void Delete()
        {
            UserAccountDeleteCommand model = Context.ModelBinder.Bind<UserAccountDeleteCommand>();
            if (model.UserKey != 0)
            {
                using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
                {
                    AccountService.DeleteAccount(model.UserKey);
                    
                    Context.Navigations.Add("Accounts.User.Deleted");
                    Context.Messages.Add(null, String.Empty, "User account deleted", MessageType.Info);
                    
                    transaction.SaveChanges();
                }
            }
        }

        #endregion

        #region Create/Update

        [Action("Accounts/User/Create")]
        public void Create()
        {
            UserAccountCreateCommand model = Context.ModelBinder.Bind<UserAccountCreateCommand>();
            IValidationResult validationResult = ValidationService.Validate(model);
            if (!validationResult.IsValid)
            {
                Context.Messages.AddValidationResult(validationResult, "UserEdit");
                return;
            }

            using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
            {
                UserAccount account = AccountService.CreateAccount(model.Username, model.Password, model.IsEnabled);
                if (model.RoleKeys != null)
                {
                    foreach (int userRoleID in model.RoleKeys)
                        AccountService.AssignAccountToRole(account, userRoleID);
                }

                Context.Messages.Add(null, String.Empty, "User account created.", MessageType.Info);
                Context.Navigations.Add("Accounts.User.Created");

                transaction.SaveChanges();
            }
        }

        [Action("Accounts/User/Update")]
        public void Update()
        {
            UserAccountEditCommand model = Context.ModelBinder.Bind<UserAccountEditCommand>();
            IValidationResult validationResult = ValidationService.Validate(model);
            if (!validationResult.IsValid)
            {
                Context.Messages.AddValidationResult(validationResult, "UserEdit");
                return;
            }

            using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
            {
                UserAccount account = UserAccounts.Get(model.Key);
                if (account == null)
                    throw new NotSupportedException();

                if (account.Username != model.Username)
                    account.Username = model.Username;

                if (!String.IsNullOrEmpty(model.Password))
                {
                    string computedPassword = PasswordProvider.ComputePassword(model.Username, model.Password);
                    if (account.Password != computedPassword)
                        account.Password = computedPassword;
                }

                if (account.IsEnabled != model.IsEnabled)
                    account.IsEnabled = model.IsEnabled;

                if (model.RoleKeys != null)
                {
                    if (account.Roles != null)
                        account.Roles.Clear();
                    else
                        account.Roles = new List<UserRole>();

                    foreach (int userRoleID in model.RoleKeys)
                        AccountService.AssignAccountToRole(account, userRoleID);
                }
                else
                {
                    if (account.Roles != null)
                        account.Roles.Clear();
                }

                UserAccounts.Update(account);

                Context.Messages.Add(null, String.Empty, "User account modified.", MessageType.Info);
                Context.Navigations.Add("Accounts.User.Updated");
                
                transaction.SaveChanges();
            }
        }

        #endregion

        #region Sign In/Out

        [Action("Accounts/Login")]
        public void Login()
        {
            UserAccountLoginModel model = Context.ModelBinder.Bind<UserAccountLoginModel>();
            bool result = AccountService.Login(model.Username, model.Password);

            if (result)
            {
                Context.Messages.Add(null, String.Empty, String.Format("Welcome, {0}.", model.Username), MessageType.Info);
                Context.Navigations.Add("Accounts.LoggedIn");
            }
            else
            {
                Context.Messages.Add(null, String.Empty, "Invalid username or password.", MessageType.Error);
            }
        }

        [Action("Accounts/Logout")]
        public void Logout()
        {
            AccountService.Logout();
            Context.Navigations.Add("Accounts.LoggedOut");
        }

        #endregion
    }
}

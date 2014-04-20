using Neptuo.Data;
using Neptuo.TemplateEngine.Accounts.Controllers.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Guard.NotNull(unitOfWorkFactory, "unitOfWorkFactory");
            Guard.NotNull(userAccounts, "userAccounts");
            Guard.NotNull(validationService, "validationService");
            Guard.NotNull(accountService, "accountService");
            UnitOfWorkFactory = unitOfWorkFactory;
            UserAccounts = userAccounts;
            ValidationService = validationService;
            AccountService = accountService;
        }

        #region Delete

        [Action("Accounts/User/Delete")]
        public string Delete(UserAccountDeleteCommand model)
        {
            if (model.UserKey != 0)
            {
                using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
                {
                    AccountService.DeleteAccount(model.UserKey);
                    
                    Messages.Add(null, String.Empty, "User account deleted", MessageType.Info);
                    
                    transaction.SaveChanges();
                    return "Accounts.User.Deleted";
                }
            }
            return null;
        }

        #endregion

        #region Create/Update

        [Action("Accounts/User/Create")]
        public string Create(UserAccountCreateCommand model)
        {
            IValidationResult validationResult = ValidationService.Validate(model);
            if (!validationResult.IsValid)
            {
                Messages.AddValidationResult(validationResult, "UserEdit");
                return null;
            }

            using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
            {
                UserAccount account = AccountService.CreateAccount(model.Username, model.Password, model.IsEnabled);
                if (model.RoleKeys != null)
                {
                    foreach (int userRoleID in model.RoleKeys)
                        AccountService.AssignAccountToRole(account, userRoleID);
                }

                Messages.Add(null, String.Empty, "User account created.", MessageType.Info);
                transaction.SaveChanges();
            }

            return "Accounts.User.Created";
        }

        [Action("Accounts/User/Update")]
        public string Update(UserAccountEditCommand model)
        {
            IValidationResult validationResult = ValidationService.Validate(model);
            if (!validationResult.IsValid)
            {
                Messages.AddValidationResult(validationResult, "UserEdit");
                return null;
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

                Messages.Add(null, String.Empty, "User account modified.", MessageType.Info);
                transaction.SaveChanges();
            }

            return "Accounts.User.Updated";
        }

        #endregion

        #region Sign In/Out

        [Action("Accounts/Login")]
        public string Login(UserAccountLoginCommand model)
        {
            bool result = AccountService.Login(model.Username, model.Password);
            if (result)
            {
                Messages.Add(null, String.Empty, String.Format("Welcome, {0}.", model.Username), MessageType.Info);
                return "Accounts.LoggedIn";
            }

            Messages.Add(null, String.Empty, "Invalid username or password.", MessageType.Error);
            return null;
        }

        [Action("Accounts/Logout")]
        public string Logout()
        {
            AccountService.Logout();
            return "Accounts.LoggedOut";
        }

        #endregion
    }
}

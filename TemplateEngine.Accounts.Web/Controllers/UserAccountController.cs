using Neptuo.Commands;
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
        protected IUserAccountRepository UserAccounts { get; private set; }
        protected ICommandDispatcher CommandDispatcher { get; private set; }
        protected IValidator<EditUserCommand> Validator { get; private set; }
        protected MessageStorage MessageStorage { get; private set; }

        public UserAccountController(IUserAccountRepository userAccounts, ICommandDispatcher commandDispatcher, IValidator<EditUserCommand> validator, MessageStorage messageStorage)
        {
            UserAccounts = userAccounts;
            CommandDispatcher = commandDispatcher;
            Validator = validator;
            MessageStorage = messageStorage;
        }

        #region Delete

        [Action("Accounts/User/Delete")]
        public void Delete()
        {
            UserDeleteModel model = Context.ModelBinder.Bind<UserDeleteModel>(new UserDeleteModel());
            if (model.UserKey != 0)
            {
                UserAccounts.Delete(UserAccounts.Get(model.UserKey));
                Context.Navigations.Add("Accounts.User.Deleted");
                MessageStorage.Add(null, String.Empty, "User account deleted", MessageType.Info);
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
            CreateUpdate();
        }

        [Action("Accounts/User/Update")]
        public void Update()
        {
            CreateUpdate();
        }

        protected void CreateUpdate()
        {
            EditUserCommand model = Context.ModelBinder.Bind<EditUserCommand>(new EditUserCommand());
            IValidationResult validationResult = Validator.Validate(model);
            if (!validationResult.IsValid)
            {
                MessageStorage.AddValidationResult(validationResult, "UserEdit");
                Context.ViewData.SetEditUserAccount(model);
                return;
            }

            CommandDispatcher.Handle(model);

            if (model.Key == 0)
            {
                MessageStorage.Add(null, String.Empty, "User account created.", MessageType.Info);
                Context.Navigations.Add("Accounts.User.Created");
            }
            else
            {
                MessageStorage.Add(null, String.Empty, "User account modified.", MessageType.Info);
                Context.Navigations.Add("Accounts.User.Updated");
            }
        }

        #endregion

    }
}

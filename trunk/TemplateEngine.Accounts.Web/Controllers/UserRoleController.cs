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
    public class UserRoleController : ControllerBase
    {
        protected IUserRoleRepository UserRoles { get; private set; }
        protected ICommandDispatcher CommandDispatcher { get; private set; }
        protected IValidator<UserRoleEditCommand> Validator { get; private set; }
        protected MessageStorage MessageStorage { get; private set; }

        public UserRoleController(IUserRoleRepository userRoles, ICommandDispatcher commandDispatcher, IValidator<UserRoleEditCommand> validator, MessageStorage messageStorage)
        {
            UserRoles = userRoles;
            CommandDispatcher = commandDispatcher;
            Validator = validator;
            MessageStorage = messageStorage;
        }

        #region Delete

        [Action("Accounts/Role/Delete")]
        public void Delete()
        {
            UserRoleDeleteModel model = Context.ModelBinder.Bind<UserRoleDeleteModel>(new UserRoleDeleteModel());
            if (model.RoleKey != 0)
            {
                UserRoles.Delete(UserRoles.Get(model.RoleKey));
                Context.Navigations.Add("Accounts.Role.Deleted");
                MessageStorage.Add(null, String.Empty, "User role deleted", MessageType.Info);
            }

        }

        public class UserRoleDeleteModel
        {
            public int RoleKey { get; set; }
        }

        #endregion

        #region Create/Update

        [Action("Accounts/Role/Create")]
        public void Create()
        {
            CreateUpdate();
        }

        [Action("Accounts/Role/Update")]
        public void Update()
        {
            Update();
        }

        protected void CreateUpdate()
        {
            UserRoleEditCommand model = Context.ModelBinder.Bind<UserRoleEditCommand>(new UserRoleEditCommand());
            IValidationResult validationResult = Validator.Validate(model);
            if (!validationResult.IsValid)
            {
                MessageStorage.Add(null, String.Empty, "Please fill all required values correctly.");

                foreach (IValidationMessage message in validationResult.Messages)
                    MessageStorage.Add(null, message.Key, message.Message, MessageType.Error);

                Context.ViewData.SetEditUserRole(model);
                return;
            }

            CommandDispatcher.Handle(model);

            if (model.Key == 0)
            {
                MessageStorage.Add(null, String.Empty, "User role created.", MessageType.Info);
                Context.Navigations.Add("Accounts.Role.Created");
            }
            else
            {
                MessageStorage.Add(null, String.Empty, "User role modified.", MessageType.Info);
                Context.Navigations.Add("Accounts.Role.Updated");
            }
        }

        #endregion
    }
}

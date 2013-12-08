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
    public class UserRoleSaveController : IController
    {
        protected ICommandDispatcher CommandDispatcher { get; private set; }
        protected IValidator<EditUserRoleCommand> Validator { get; private set; }
        protected MessageStorage MessageStorage { get; private set; }

        public UserRoleSaveController(ICommandDispatcher commandDispatcher, IValidator<EditUserRoleCommand> validator, MessageStorage messageStorage)
        {
            CommandDispatcher = commandDispatcher;
            Validator = validator;
            MessageStorage = messageStorage;
        }

        public void Execute(IControllerContext context)
        {
            EditUserRoleCommand model = context.ModelBinder.Bind<EditUserRoleCommand>(new EditUserRoleCommand());
            IValidationResult validationResult = Validator.Validate(model);
            if (!validationResult.IsValid)
            {
                MessageStorage.Add(null, String.Empty, "Please fill all required values correctly.");

                foreach (IValidationMessage message in validationResult.Messages)
                    MessageStorage.Add(null, message.Key, message.Message, MessageType.Error);

                context.ViewData.SetEditUserRole(model);
                return;
            }

            CommandDispatcher.Handle(model);
            MessageStorage.Add(null, String.Empty, "User role saved.", MessageType.Info);
        }
    }

    public class UserRoleDeleteController : IController
    {
        protected IUserRoleRepository UserRoles { get; private set; }
        protected MessageStorage MessageStorage { get; private set; }

        public UserRoleDeleteController(IUserRoleRepository userRoles, MessageStorage messageStorage)
        {
            UserRoles = userRoles;
            MessageStorage = messageStorage;
        }

        public void Execute(IControllerContext context)
        {
            UserRoleDeleteModel model = context.ModelBinder.Bind<UserRoleDeleteModel>(new UserRoleDeleteModel());
            if (model.RoleKey != 0)
            {
                UserRoles.Delete(UserRoles.Get(model.RoleKey));
                context.Navigations.Add("Accounts.Role.Deleted");
                MessageStorage.Add(null, String.Empty, "User role deleted", MessageType.Info);
            }
        }

        public class UserRoleDeleteModel
        {
            public int RoleKey { get; set; }
        }
    }

}

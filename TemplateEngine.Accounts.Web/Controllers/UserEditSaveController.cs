using Neptuo.Commands;
using Neptuo.TemplateEngine.Accounts.Commands;
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
    public class UserEditSaveController : IController
    {
        protected ICommandDispatcher CommandDispatcher { get; private set; }
        protected IValidator<EditUserCommand> Validator { get; private set; }
        protected MessageStorage MessageStorage { get; private set; }

        public UserEditSaveController(ICommandDispatcher commandDispatcher, IValidator<EditUserCommand> validator, MessageStorage messageStorage)
        {
            CommandDispatcher = commandDispatcher;
            Validator = validator;
            MessageStorage = messageStorage;
        }

        public void Execute(IControllerContext context)
        {
            EditUserCommand model = context.ModelBinder.Bind<EditUserCommand>(new EditUserCommand());
            IValidationResult validationResult = Validator.Validate(model);
            if (!validationResult.IsValid)
            {
                MessageStorage.Add(null, String.Empty, "Please fill all required values correctly.");

                foreach (IValidationMessage message in validationResult.Messages)
                    MessageStorage.Add(null, message.Key, message.Message, MessageType.Error);

                context.ViewData.SetEditUserAccount(model);
                return;
            }

            CommandDispatcher.Handle(model);
            MessageStorage.Add(null, String.Empty, "User account saved.", MessageType.Info);
        }
    }
}

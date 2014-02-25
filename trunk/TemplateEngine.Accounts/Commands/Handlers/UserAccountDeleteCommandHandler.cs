using Neptuo.Events;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Events;
using Neptuo.TemplateEngine.Commands.Handlers;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Commands.Handlers
{
    public class UserAccountDeleteCommandHandler : CommandHandlerBase<UserAccountDeleteCommand>
    {
        protected IEventDispatcher EventDispatcher { get; private set; }
        protected IUserAccountRepository UserAccounts { get; private set; }

        public UserAccountDeleteCommandHandler(IUserAccountRepository userAccounts, IEventDispatcher eventDispatcher)
        {
            Guard.NotNull(userAccounts, "userAccounts");
            Guard.NotNull(eventDispatcher, "eventDispatcher");
            UserAccounts = userAccounts;
            EventDispatcher = eventDispatcher;
        }

        protected override void HandleValidCommand(UserAccountDeleteCommand command)
        {
            UserAccounts.Delete(UserAccounts.Get(command.UserKey));
            EventDispatcher.Publish(new UserAccountDeleted(command.UserKey));
        }

        protected override void ValidateCommand(UserAccountDeleteCommand command, List<IValidationMessage> messages)
        { }
    }
}

using Neptuo.Commands.Events;
using Neptuo.Data;
using Neptuo.Events;
using Neptuo.Linq.Expressions;
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
    public class UserAccountEditCommandHandler : CommandHandlerBase<UserAccountEditCommand>
    {
        protected IEventDispatcher EventDispatcher { get; private set; }
        protected IUserAccountRepository UserAccounts { get; private set; }
        protected IUnitOfWorkFactory TransactionFactory { get; private set; }

        public UserAccountEditCommandHandler(IEventDispatcher eventDispatcher, IUnitOfWorkFactory transactionFactory, IUserAccountRepository userAccounts)
        {
            EventDispatcher = eventDispatcher;
            UserAccounts = userAccounts;
            TransactionFactory = transactionFactory;
        }

        protected override void HandleValidCommand(UserAccountEditCommand command)
        {
            UserAccount userAccount = UserAccounts.Get(command.Key);
            if (userAccount == null)
                userAccount = UserAccounts.Create();

            if (userAccount.Username != command.Username)
                userAccount.Username = command.Username;

            if (userAccount.Password != command.Password && !String.IsNullOrEmpty(command.Password))
                userAccount.Password = command.Password;

            if (userAccount.IsEnabled != command.IsEnabled)
                userAccount.IsEnabled = command.IsEnabled;

            if (userAccount.Key == 0)
                UserAccounts.Insert(userAccount);
            else
                UserAccounts.Update(userAccount);

            EventDispatcher.Publish(new CommandHandled(command));
            EventDispatcher.Publish(new UserAccountUpdated(userAccount.Key));
        }

        protected override void ValidateCommand(UserAccountEditCommand command, List<IValidationMessage> messages)
        {
            if (String.IsNullOrEmpty(command.Username))
                messages.Add(new TextValidationMessage(TypeHelper.PropertyName<UserAccountEditCommand, string>(c => c.Username), "Username can't be empty!"));

            if (!String.IsNullOrEmpty(command.Password))
            {
                if (command.Password != command.PasswordAgain)
                    messages.Add(new TextValidationMessage(TypeHelper.PropertyName<UserAccountEditCommand, string>(c => c.PasswordAgain), "Passwords must match!"));
            }
        }
    }
}

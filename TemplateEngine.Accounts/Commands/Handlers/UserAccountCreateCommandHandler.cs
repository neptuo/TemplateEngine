using Neptuo.Commands.Events;
using Neptuo.Commands.Handlers;
using Neptuo.Commands.Validation;
using Neptuo.Data;
using Neptuo.Events;
using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Commands.Handlers;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Commands.Handlers
{
    public class UserAccountCreateCommandHandler : CommandHandlerBase<UserAccountCreateCommand>
    {
        protected IEventDispatcher EventDispatcher { get; private set; }
        protected IUserAccountRepository UserAccounts { get; private set; }
        protected IUnitOfWorkFactory TransactionFactory { get; private set; }

        public UserAccountCreateCommandHandler(IEventDispatcher eventDispatcher, IUnitOfWorkFactory transactionFactory, IUserAccountRepository userAccounts)
        {
            EventDispatcher = eventDispatcher;
            UserAccounts = userAccounts;
            TransactionFactory = transactionFactory;
        }

        protected override void HandleValidCommand(UserAccountCreateCommand command)
        {
            using (IUnitOfWork transaction = TransactionFactory.Create())
            {
                UserAccount userAccount = UserAccounts.Create();
                userAccount.Username = command.Username;
                userAccount.Password = command.Password;
                userAccount.IsEnabled = command.IsEnabled;

                UserAccounts.Insert(userAccount);
                transaction.SaveChanges();
                EventDispatcher.Publish(new CommandHandled(command));
            }
        }

        protected override void ValidateCommand(UserAccountCreateCommand command, List<IValidationMessage> messages)
        {
            if (String.IsNullOrEmpty(command.Username))
                messages.Add(new TextValidationMessage(TypeHelper.PropertyName<UserAccountEditCommand, string>(c => c.Username), "Username can't be empty!"));

            if (String.IsNullOrEmpty(command.Password))
                messages.Add(new TextValidationMessage(TypeHelper.PropertyName<UserAccountEditCommand, string>(c => c.Password), "Password can't be empty!"));

            if (command.Password != command.PasswordAgain)
                messages.Add(new TextValidationMessage(TypeHelper.PropertyName<UserAccountEditCommand, string>(c => c.PasswordAgain), "Passwords must match!"));
        }
    }
}

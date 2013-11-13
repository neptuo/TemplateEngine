using Neptuo.Commands.Handlers;
using Neptuo.Commands.Validation;
using Neptuo.Data;
using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Commands.Handlers
{
    public class EditUserCommandHandler : ICommandHandler<EditUserCommand>, IValidator<EditUserCommand>
    {
        protected IUserAccountRepository UserAccounts { get; private set; }
        protected IUnitOfWorkFactory TransactionFactory { get; private set; }

        public EditUserCommandHandler(IUnitOfWorkFactory transactionFactory, IUserAccountRepository userAccounts)
        {
            UserAccounts = userAccounts;
            TransactionFactory = transactionFactory;
        }

        public void Handle(EditUserCommand command)
        {
            IValidationResult validation = Validate(command);
            if (!validation.IsValid)
                throw new InvalidOperationException("Command is not valid.");//TODO: Do it better!

            using (IUnitOfWork transaction = TransactionFactory.Create())
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

                transaction.SaveChanges();
            }
        }

        public IValidationResult Validate(EditUserCommand command)
        {
            List<IValidationMessage> messages = new List<IValidationMessage>();

            if (String.IsNullOrEmpty(command.Username))
                messages.Add(new TextValidationMessage(TypeHelper.PropertyName<EditUserCommand, string>(c => c.Username), "Username can't be empty!"));

            if (String.IsNullOrEmpty(command.Password))
                messages.Add(new TextValidationMessage(TypeHelper.PropertyName<EditUserCommand, string>(c => c.Password), "Password can't be empty!"));

            if (command.Password != command.PasswordAgain)
                messages.Add(new TextValidationMessage(TypeHelper.PropertyName<EditUserCommand, string>(c => c.PasswordAgain), "Passwords must match!"));

            return new ValidationResultBase(!messages.Any(), messages);
        }
    }
}

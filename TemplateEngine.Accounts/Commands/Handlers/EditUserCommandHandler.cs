using Neptuo.Data.Commands.Handlers;
using Neptuo.TemplateEngine.Accounts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Commands.Handlers
{
    public class EditUserCommandHandler : ICommandHandler<EditUserCommand>
    {
        protected IUserAccountRepository UserAccounts { get; private set; }

        public EditUserCommandHandler(IUserAccountRepository userAccounts)
        {
            UserAccounts = userAccounts;
        }

        public void Handle(EditUserCommand command)
        {
            UserAccount userAccount = UserAccounts.Get(command.Key);
            if (userAccount == null)
                userAccount = UserAccounts.Create();

            if (userAccount.Username != command.Username)
                userAccount.Username = command.Username;

            if (userAccount.Password != command.Password)
                userAccount.Password = command.Password;

            if (userAccount.IsEnabled != command.IsEnabled)
                userAccount.IsEnabled = command.IsEnabled;
        }
    }
}

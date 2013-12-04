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
    public class EditUserRoleCommandHandler : ICommandHandler<EditUserRoleCommand>, IValidator<EditUserRoleCommand>
    {
        protected IUserRoleRepository UserRoles { get; private set; }
        protected IUnitOfWorkFactory TransactionFactory { get; private set; }

        public EditUserRoleCommandHandler(IUnitOfWorkFactory transactionFactory, IUserRoleRepository userRoles)
        {
            UserRoles = userRoles;
            TransactionFactory = transactionFactory;
        }

        public void Handle(EditUserRoleCommand command)
        {
            IValidationResult validation = Validate(command);
            if (!validation.IsValid)
                throw new InvalidOperationException("Command is not valid.");//TODO: Do it better!

            using (IUnitOfWork transaction = TransactionFactory.Create())
            {
                UserRole userRole = UserRoles.Get(command.Key);
                if (userRole == null)
                    userRole = UserRoles.Create();

                if (userRole.Name != command.Name)
                    userRole.Name = command.Name;

                if (userRole.Description != command.Description)
                    userRole.Description = command.Description;

                if (userRole.Key == 0)
                    UserRoles.Insert(userRole);
                else
                    UserRoles.Update(userRole);

                transaction.SaveChanges();
            }
        }

        public IValidationResult Validate(EditUserRoleCommand model)
        {
            List<IValidationMessage> messages = new List<IValidationMessage>();

            if (String.IsNullOrEmpty(model.Name))
                messages.Add(new TextValidationMessage(TypeHelper.PropertyName<EditUserRoleCommand, string>(c => c.Name), "Name can't be empty!"));

            return new ValidationResultBase(!messages.Any(), messages);
        }
    }
}

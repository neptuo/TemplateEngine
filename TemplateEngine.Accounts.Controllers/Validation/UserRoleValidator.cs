using Neptuo.Data.Queries;
using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Accounts.Controllers.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Controllers.Validation
{
    public class UserRoleValidator : IValidator<UserRoleCreateCommand>, IValidator<UserRoleEditCommand>
    {
        private static readonly string nameKey = TypeHelper.PropertyName<UserRoleCreateCommand, string>(c => c.Name);

        private readonly UserRoleDataProvider userRoles;

        public UserRoleValidator(UserRoleDataProvider userRoles)
        {
            Guard.NotNull(userRoles, "userRoles");
            this.userRoles = userRoles;
        }

        public IValidationResult Validate(UserRoleCreateCommand model)
        {
            List<IValidationMessage> messages = new List<IValidationMessage>();
            ValidateName(null, model.Name, messages);
            return new ValidationResultBase(!messages.Any(), messages);
        }

        public IValidationResult Validate(UserRoleEditCommand model)
        {
            List<IValidationMessage> messages = new List<IValidationMessage>();
            ValidateName(model.Key, model.Name, messages);
            return new ValidationResultBase(!messages.Any(), messages);
        }

        private void ValidateName(int? key, string name, List<IValidationMessage> messages)
        {
            if (String.IsNullOrEmpty(name))
                messages.Add(new StringNullOrEmptyMessage(nameKey));
            else if (IsNameUsed(key, name))
                messages.Add(new TextValidationMessage(nameKey, "Name is already taken aby another role!"));
        }

        private bool IsNameUsed(int? key, string name)
        {
            var query = userRoles.Query();
            query.Filter.Name = TextSearch.Create(name);

            IEnumerable<int> keys = query.EnumerateItems(u => u.Key);
            if (key == null)
                return keys.Any();

            return !keys.All(k => k == key.Value);
        }
    }
}

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
    public class UserAccountValidator : IValidator<UserAccountCreateCommand>, IValidator<UserAccountEditCommand>
    {
        private static readonly string usernameKey = TypeHelper.PropertyName<UserAccountEditCommand, string>(c => c.Username);
        private static readonly string passwordKey = TypeHelper.PropertyName<UserAccountEditCommand, string>(c => c.Password);
        private static readonly string passwordAgainKey = TypeHelper.PropertyName<UserAccountEditCommand, string>(c => c.PasswordAgain);

        private readonly UserAccountDataProvider userAccounts;

        public UserAccountValidator(UserAccountDataProvider userAccounts)
        {
            Guard.NotNull(userAccounts, "userAccounts");
            this.userAccounts = userAccounts;
        }

        public IValidationResult Validate(UserAccountCreateCommand model)
        {
            List<IValidationMessage> messages = new List<IValidationMessage>();
            ValidateUsername(null, model.Username, messages);
            ValidatePassword(null, model.Password, model.Password, messages);
            return new ValidationResultBase(!messages.Any(), messages);
        }

        public IValidationResult Validate(UserAccountEditCommand model)
        {
            List<IValidationMessage> messages = new List<IValidationMessage>();
            ValidateUsername(model.Key, model.Username, messages);
            ValidatePassword(model.Key, model.Password, model.Password, messages);
            return new ValidationResultBase(!messages.Any(), messages);
        }

        private void ValidateUsername(int? key, string username, List<IValidationMessage> messages)
        {
            if (String.IsNullOrEmpty(username))
                messages.Add(new StringNullOrEmptyMessage(usernameKey));
            else if (username.Length < 5)
                messages.Add(new StringLengthMessage(usernameKey, 5, null));
            else if (IsUsernameUsed(key, username))
                messages.Add(new TextValidationMessage(usernameKey, "Username is already taken by another user!"));
        }

        private void ValidatePassword(int? key, string password, string passwordAgain, List<IValidationMessage> messages)
        {
            if (key == null)
            {
                if (String.IsNullOrEmpty(password))
                    messages.Add(new StringNullOrEmptyMessage(passwordKey));
                else if (password.Length < 5)
                    messages.Add(new StringLengthMessage(passwordKey, 5, null));
                else if (password != passwordAgain)
                    messages.Add(new PropertyEqualMessage(passwordAgainKey, passwordAgainKey, passwordKey));
            } 
            else if (!String.IsNullOrEmpty(password))
            {
                if (password.Length < 5)
                    messages.Add(new StringLengthMessage(passwordKey, 5, null));
                else if (password != passwordAgain)
                    messages.Add(new PropertyEqualMessage(passwordAgainKey, passwordAgainKey, passwordKey));
            }
        }

        private bool IsUsernameUsed(int? key, string username)
        {
            var query = userAccounts.Query();
            query.Filter.Username = TextSearch.Create(username);

            IEnumerable<int> keys = query.EnumerateItems(u => u.Key);
            if (key == null)
                return keys.Any();

            return !keys.All(k => k == key.Value);
        }
    }
}

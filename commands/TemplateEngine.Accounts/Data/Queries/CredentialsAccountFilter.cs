using Neptuo.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Queries
{
    public class CredentialsAccountFilter : UserAccountFilter
    {
        public CredentialsAccountFilter(string username, string password)
        {
            Username = TextSearch.Create(username);
            Password = TextSearch.Create(PasswordProvider.ComputePassword(username, password));
            IsEnabled = BoolSearch.True();
        }
    }
}

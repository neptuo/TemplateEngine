using Neptuo.TemplateEngine.Accounts.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data
{
    public class UserAccountDataProvider : DataProviderBase<UserAccount, IUserAccountQuery, IUserAccountRepository>
    {
        public UserAccountDataProvider(IUserAccountRepository repository, IActivator<IUserAccountQuery> query)
            : base(repository, query, repository)
        { }
    }
}

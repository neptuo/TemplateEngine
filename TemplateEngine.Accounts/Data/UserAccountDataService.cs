using Neptuo.TemplateEngine.Accounts.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data
{
    public class UserAccountDataService
    {
        public IUserAccountQuery Query { get; private set; }
        public IUserAccountRepository Repository { get; private set; }
        public IActivator<UserAccount> Factory { get; private set; }

        public UserAccountDataService(IUserAccountQuery query, IUserAccountRepository repository, IActivator<UserAccount> factory)
        {
            Query = query;
            Repository = repository;
            Factory = factory;
        }
    }
}

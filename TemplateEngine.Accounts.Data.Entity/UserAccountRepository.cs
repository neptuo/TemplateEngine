using Neptuo.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Queries;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity
{
    public class UserAccountRepository : MappingEntityRepository<UserAccount, UserAccountEntity, int, IAccountDbContext>, IUserAccountRepository, IUserQuery
    {
        public UserAccountRepository(IAccountDbContext dbContext)
            : base(dbContext)
        { }

        public UserAccount Create()
        {
            return new UserAccountEntity();
        }

        public IEnumerable<UserAccount> Get()
        {
            return DbContext.UserAccounts;
        }
    }
}

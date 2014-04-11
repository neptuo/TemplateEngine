using Neptuo.Data;
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
    public class EntityUserAccountRepository : MappingEntityRepository<UserAccount, UserAccountEntity, int, DataContext>, IUserAccountRepository, IDeprecatedUserAccountQuery
    {
        public EntityUserAccountRepository(DataContext dbContext)
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

        public IEnumerable<UserAccount> Get(int pageIndex, int pageSize)
        {
            return DbContext.UserAccounts.Skip(pageIndex * pageSize).Take(pageSize);
        }

        public UserAccount Get(Key key)
        {
            if (key == null)
                throw new ArgumentNullException("key");

            return DbContext.UserAccounts.FirstOrDefault(u => u.Key == key.ID);
        }

        public UserAccount Get(string username, string password)
        {
            return DbContext.UserAccounts.FirstOrDefault(u => u.Username == username && u.Password == password && u.IsEnabled);
        }
    }
}

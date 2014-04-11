using Neptuo.Data;
using Neptuo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity
{
    public class EntityUserAccountRepository : EntityRepository<UserAccount, int, DataContext>, IUserAccountRepository
    {
        public EntityUserAccountRepository(DataContext dbContext)
            : base(dbContext)
        { }

        public UserAccount Create()
        {
            return DbContext.UserAccounts.Create();
        }
    }
}

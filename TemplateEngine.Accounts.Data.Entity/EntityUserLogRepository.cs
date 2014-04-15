using Neptuo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity
{
    public class EntityUserLogRepository : EntityRepository<UserLog, Guid, DataContext>, IUserLogRepository
    {
        public EntityUserLogRepository(DataContext dbContext)
            : base(dbContext)
        { }

        public UserLog Create()
        {
            return DbContext.UserLogs.Create();
        }
    }
}

using Neptuo.Data;
using Neptuo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity
{
    public class EntityUserRoleRepository : EntityRepository<UserRole, int, DataContext>, IUserRoleRepository
    {
        public EntityUserRoleRepository(DataContext dbContext)
            : base(dbContext)
        { }

        public UserRole Create()
        {
            return DbContext.UserRoles.Create();
        }
    }
}

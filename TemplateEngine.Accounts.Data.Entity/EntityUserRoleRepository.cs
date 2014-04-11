using Neptuo.Data;
using Neptuo.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity
{
    public class EntityUserRoleRepository : EntityRepository<UserRole, int, DataContext>, IUserRoleRepository, IDeprecatedUserRoleQuery
    {
        public EntityUserRoleRepository(DataContext dbContext)
            : base(dbContext)
        { }

        public UserRole Create()
        {
            return new UserRole();
        }

        public IEnumerable<UserRole> Get()
        {
            return DbContext.UserRoles;
        }

        public IEnumerable<UserRole> Get(int pageIndex, int pageSize)
        {
            return DbContext.UserRoles.Skip(pageIndex * pageSize).Take(pageSize);
        }
    }
}

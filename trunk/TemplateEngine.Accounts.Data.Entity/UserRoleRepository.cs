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
    public class UserRoleRepository : MappingEntityRepository<UserRole, UserRoleEntity, int, IAccountDbContext>, IUserRoleRepository, IUserRoleQuery
    {
        public UserRoleRepository(IAccountDbContext dbContext)
            : base(dbContext)
        { }

        public UserRole Create()
        {
            return new UserRoleEntity();
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

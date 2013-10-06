using Neptuo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity
{
    public class UserRoleRepository : MappingEntityRepository<UserRole, UserRoleEntity, int, IAccountDbContext>, IUserRoleRepository
    {
        public UserRoleRepository(IAccountDbContext dbContext)
            : base(dbContext)
        { }

        public UserRole Create()
        {
            return new UserRoleEntity();
        }
    }
}

using Neptuo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity
{
    public interface IAccountDbContext : IDbContext
    {
        DbSet<UserAccountEntity> UserAccounts { get; }
        DbSet<UserRoleEntity> UserRoles { get; }
    }
}

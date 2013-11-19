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
        IDbSet<UserAccountEntity> UserAccounts { get; }
        IDbSet<UserRoleEntity> UserRoles { get; }
    }
}

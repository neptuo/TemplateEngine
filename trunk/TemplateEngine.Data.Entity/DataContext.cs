using Neptuo.TemplateEngine.Accounts.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateEngine.Data.Entity
{
    public class DataContext : DbContext, IAccountDbContext
    {
        public IDbSet<UserAccountEntity> UserAccounts { get; set; }
        public IDbSet<UserRoleEntity> UserRoles { get; set; }
    }
}

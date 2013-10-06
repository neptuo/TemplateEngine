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
        public DbSet<UserAccountEntity> UserAccounts { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
    }
}

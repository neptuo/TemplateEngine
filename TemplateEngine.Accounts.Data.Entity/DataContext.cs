using Neptuo.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity
{
    public class DataContext : DbContext, IDbContext
    {
        public IDbSet<UserAccountEntity> UserAccounts { get; set; }
        public IDbSet<UserRoleEntity> UserRoles { get; set; }

        public DataContext()
        { }
    }
}

using Neptuo.TemplateEngine.Accounts.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Hosting.Data.Entity
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);

            context.UserRoles.Add(new UserRole
            {
                Name = "Administrators",
                Description = "System admins"
            });
            context.UserRoles.Add(new UserRole
            {
                Name = "Everyone",
                Description = "Public (un-authenticated) users"
            });

            context.UserAccounts.Add(new UserAccount
            {
                Username = "admin",
                Password = PasswordProvider.ComputePassword("admin", "admin"),
                IsEnabled = true
            });

            //context.UserAccounts.First(a => a.Key == 1).Roles.Add(context.UserRoles.First(r => r.Key == 1));
        }
    }
}

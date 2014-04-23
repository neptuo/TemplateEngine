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
            context.SaveChanges();

            UserAccount admin = context.UserAccounts.Find(1);
            admin.Roles = new List<UserRole>();
            admin.Roles.Add(context.UserRoles.Find(1));


            // Login for everyone
            UserRole everyone = context.UserRoles.Find(2);
            InsertPermission(context, everyone, "Accounts.Login", "ReadWrite");
        

            // Every thing for admins
            UserRole admins = context.UserRoles.Find(1);
            InsertPermission(context, admins, "Home", "ReadWrite");
            InsertPermission(context, admins, "Accounts.User.List", "ReadWrite");
            InsertPermission(context, admins, "Accounts.User.Edit", "ReadWrite");
            InsertPermission(context, admins, "Accounts.Role.List", "ReadWrite");
            InsertPermission(context, admins, "Accounts.Role.Edit", "ReadWrite");
            InsertPermission(context, admins, "Accounts.Log.List", "ReadWrite");
            InsertPermission(context, admins, "Accounts.Permission.List", "ReadWrite");

            context.SaveChanges();
        }

        private void InsertPermission(DataContext context, UserRole role, string resourceName, string permissionName)
        {
            context.Permissions.Add(new ResourcePermission
            {
                ResourceName = resourceName,
                PermissionName = permissionName,
                Role = role
            });
        }
    }
}

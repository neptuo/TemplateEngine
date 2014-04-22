using Neptuo.Data;
using Neptuo.Data.Queries;
using Neptuo.TemplateEngine.Accounts.Controllers.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Controllers
{
    public class ResourcePermissionController : ControllerBase
    {
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }
        protected ResourcePermissionDataProvider Permissions { get; private set; }
        protected UserRoleDataProvider UserRoles { get; private set; }

        public ResourcePermissionController(IUnitOfWorkFactory unitOfWorkFactory, ResourcePermissionDataProvider permissions, UserRoleDataProvider userRoles)
        {
            Guard.NotNull(unitOfWorkFactory, "unitOfWorkFactory");
            Guard.NotNull(permissions, "permissions");
            Guard.NotNull(userRoles, "userRoles");
            UnitOfWorkFactory = unitOfWorkFactory;
            Permissions = permissions;
            UserRoles = userRoles;
        }

        #region Update permissions

        [Action("Accounts/Permission/Update")]
        public string UpdatePermissions(ResourcePermissionUpdateCommand model)
        {
            UserRole role = UserRoles.Repository.Get(model.RoleKey);
            if(role == null)
            {
                Context.Messages.Add(null, String.Empty, "Unnable to find role.", MessageType.Error);
                return "Accounts.Permission.Updated";
            }

            if (model.ResourceName == null)
            {
                Context.Messages.Add(null, String.Empty, "Missing resource name.", MessageType.Error);
                return null;
            }

            using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
            {
                var deleteQuery = Permissions.Query();
                deleteQuery.Filter.RoleKey = IntSearch.Create(model.RoleKey);
                deleteQuery.Filter.ResourceName = TextSearch.Create(model.ResourceName);

                foreach (ResourcePermission permission in deleteQuery.EnumerateItems())
                    Permissions.Repository.Delete(permission);

                if (model.PermissionNames != null)
                {
                    foreach (string permissionName in model.PermissionNames)
                    {
                        ResourcePermission permission = Permissions.Factory.Create();
                        permission.ResourceName = model.ResourceName;
                        permission.PermissionName = permissionName;
                        permission.Role = role;

                        Permissions.Repository.Insert(permission);
                    }
                }

                Context.Messages.Add(null, String.Empty, "Permissions updated.", MessageType.Info);
                transaction.SaveChanges();
            }

            return "Accounts.Permission.Updated";
        }

        #endregion
    }
}

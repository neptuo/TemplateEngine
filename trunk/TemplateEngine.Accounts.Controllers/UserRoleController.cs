using Neptuo.TemplateEngine.Accounts.Controllers.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.Data;
using Neptuo.TemplateEngine.Providers;

namespace Neptuo.TemplateEngine.Accounts.Controllers
{
    public class UserRoleController : ControllerBase
    {
        protected IUnitOfWorkFactory UnitOfWorkFactory { get; private set; }
        protected UserRoleDataProvider UserRoles { get; private set; }
        protected IValidatorService ValidationService { get; private set; }

        public UserRoleController(IUnitOfWorkFactory unitOfWorkFactory, UserRoleDataProvider userRoles, IValidatorService validationService)
        {
            Guard.NotNull(unitOfWorkFactory, "unitOfWorkFactory");
            Guard.NotNull(userRoles, "userRoles");
            Guard.NotNull(validationService, "validationService");
            UnitOfWorkFactory = unitOfWorkFactory;
            UserRoles = userRoles;
            ValidationService = validationService;
        }

        #region Delete

        [Action("Accounts/Role/Delete")]
        public string Delete(UserRoleDeleteCommand model)
        {
            if (model.RoleKey != 0)
            {
                using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
                {
                    UserRoles.Repository.Delete(UserRoles.Repository.Get(model.RoleKey));
                    Messages.Add(null, String.Empty, "User role deleted", MessageType.Info);
                    transaction.SaveChanges();

                    return "Accounts.Role.Deleted";
                }
            }

            return null;
        }

        #endregion

        #region Create/Update

        [Action("Accounts/Role/Create")]
        public string Create(UserRoleCreateCommand model)
        {
            IValidationResult validationResult = ValidationService.Validate(model);
            if (!validationResult.IsValid)
            {
                Messages.AddValidationResult(validationResult, "RoleEdit");
                return null;
            }

            using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
            {
                UserRole role = UserRoles.Factory.Create();
                role.Name = model.Name;
                role.Description = model.Description;

                UserRoles.Repository.Insert(role);
                Messages.Add(null, String.Empty, "User role created.", MessageType.Info);

                transaction.SaveChanges();
            }

            return "Accounts.Role.Created";
        }

        [Action("Accounts/Role/Update")]
        public string Update(UserRoleEditCommand model)
        {
            IValidationResult validationResult = ValidationService.Validate(model);
            if (!validationResult.IsValid)
            {
                Messages.AddValidationResult(validationResult, "RoleEdit");
                return null;
            }

            using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
            {
                UserRole userRole = UserRoles.Repository.Get(model.Key);
                if (userRole == null)
                    throw new NotSupportedException();

                if (userRole.Name != model.Name)
                    userRole.Name = model.Name;

                if (userRole.Description != model.Description)
                    userRole.Description = model.Description;

                UserRoles.Repository.Update(userRole);
                Messages.Add(null, String.Empty, "User role modified.", MessageType.Info);
                
                transaction.SaveChanges();
            }

            return "Accounts.Role.Updated";
        }

        #endregion
    }
}

using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Providers;
using Neptuo.Data;

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
        public void Delete()
        {
            UserRoleDeleteCommand model = Context.ModelBinder.Bind<UserRoleDeleteCommand>();
            if (model.RoleKey != 0)
            {
                using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
                {
                    UserRoles.Repository.Delete(UserRoles.Repository.Get(model.RoleKey));
                    
                    Context.Navigations.Add("Accounts.Role.Deleted");
                    Context.Messages.Add(null, String.Empty, "User role deleted", MessageType.Info);

                    transaction.SaveChanges();
                }
            }

        }

        #endregion

        #region Create/Update

        [Action("Accounts/Role/Create")]
        public void Create()
        {
            UserRoleCreateCommand model = Context.ModelBinder.Bind<UserRoleCreateCommand>();
            IValidationResult validationResult = ValidationService.Validate(model);
            if (!validationResult.IsValid)
            {
                Context.Messages.AddValidationResult(validationResult, "RoleEdit");
                return;
            }

            using (IUnitOfWork transaction = UnitOfWorkFactory.Create())
            {
                UserRole role = UserRoles.Factory.Create();
                role.Name = model.Name;
                role.Description = model.Description;

                UserRoles.Repository.Insert(role);

                Context.Messages.Add(null, String.Empty, "User role created.", MessageType.Info);
                Context.Navigations.Add("Accounts.Role.Created");

                transaction.SaveChanges();
            }
        }

        [Action("Accounts/Role/Update")]
        public void Update()
        {
            UserRoleEditCommand model = Context.ModelBinder.Bind<UserRoleEditCommand>();
            IValidationResult validationResult = ValidationService.Validate(model);
            if (!validationResult.IsValid)
            {
                Context.Messages.AddValidationResult(validationResult, "RoleEdit");
                return;
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

                Context.Messages.Add(null, String.Empty, "User role modified.", MessageType.Info);
                Context.Navigations.Add("Accounts.Role.Updated");
                
                transaction.SaveChanges();
            }

        }

        #endregion
    }
}

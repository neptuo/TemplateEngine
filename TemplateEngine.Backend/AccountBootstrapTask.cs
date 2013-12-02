using Neptuo.Bootstrap;
using Neptuo.Commands.Handlers;
using Neptuo.Lifetimes;
using Neptuo.TemplateEngine.Accounts;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Commands.Handlers;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Queries;
using Neptuo.TemplateEngine.Accounts.Web.Controllers;
using Neptuo.TemplateEngine.Backend.Web.Routing;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Compilation.Parsers;
using Neptuo.TemplateEngine.Web.Controllers;
using Neptuo.Templates.Compilation;
using Neptuo.Templates.Compilation.Parsers;
using Neptuo.Validation;
using Neptuo.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Data.Entity;

namespace Neptuo.TemplateEngine.Backend
{
    public class AccountBootstrapTask : IBootstrapTask
    {
        private IDependencyContainer dependencyContainer;
        private TypeBuilderRegistry registry;
        private IFormUriRegistry formRegistry;
        private IControllerRegistry controllerRegistry;

        public AccountBootstrapTask(IDependencyContainer dependencyContainer, TypeBuilderRegistry registry, IFormUriRegistry formRegistry, IControllerRegistry controllerRegistry)
        {
            this.dependencyContainer = dependencyContainer;
            this.registry = registry;
            this.formRegistry = formRegistry;
            this.controllerRegistry = controllerRegistry;
        }

        public void Initialize()
        {
            dependencyContainer
                //.RegisterInstance<IAccountDbContext>()
                .RegisterType<IUserAccountRepository, MemoryUserAccountRepository>(new SingletonLifetime())
                .RegisterType<IActivator<UserAccount>, MemoryUserAccountRepository>(new SingletonLifetime())
                .RegisterType<IUserAccountQuery, MemoryUserAccountRepository>(new SingletonLifetime())

                .RegisterType<IUserRoleRepository, MemoryUserRoleRepository>(new SingletonLifetime())
                .RegisterType<IActivator<UserRole>, MemoryUserRoleRepository>(new SingletonLifetime())
                .RegisterType<IUserRoleQuery, MemoryUserRoleRepository>(new SingletonLifetime())

                .RegisterType<ICommandHandler<EditUserCommand>, EditUserCommandHandler>(new PerRequestLifetime())
                .RegisterType<IValidator<EditUserCommand>, EditUserCommandHandler>(new PerRequestLifetime());

            registry.RegisterNamespace(new NamespaceDeclaration("ui", "Neptuo.TemplateEngine.Accounts.Web.Presenters, Neptuo.TemplateEngine.Accounts.Web"));
            registry.RegisterNamespace(new NamespaceDeclaration("data", "Neptuo.TemplateEngine.Accounts.Web.DataSources, Neptuo.TemplateEngine.Accounts.Web"));
            
            registry.RegisterComponentBuilder("ui", "AccountSideNav", new UserTemplateComponentBuilderFactory("~/Views/Accounts/SideNav.view"));

            formRegistry
                .Register("Accounts.User.List", TemplateRouteParameter.FormatUrl("~/Accounts/UserList"))
                .Register("Accounts.User.Edit", TemplateRouteParameter.FormatUrl("~/Accounts/UserEdit"))

                .Register("Accounts.Role.List", TemplateRouteParameter.FormatUrl("~/Accounts/RoleList"))
                .Register("Accounts.Role.Edit", TemplateRouteParameter.FormatUrl("~/Accounts/RoleEdit"));

            controllerRegistry
                .Add("Accounts/User/Save", dependencyContainer, typeof(UserEditSaveController))
                .Add("Accounts/Role/Save", dependencyContainer, typeof(UserRoleSaveController));

#if DEBUG
            CreateDummyUserAccounts();
            CreateDummyUserRoles();
#endif
        }

        protected void CreateDummyUserAccounts()
        {
            IUserAccountRepository storage = dependencyContainer.Resolve<IUserAccountRepository>();
            for (int i = 0; i < 34; i++)
            {
                storage.Insert(new MemoryUserAccount
                {
                    Username = "User " + i,
                    IsEnabled = (i % 3) == 1
                });
            }
        }

        protected void CreateDummyUserRoles()
        {
            IUserRoleRepository storage = dependencyContainer.Resolve<IUserRoleRepository>();
            storage.Insert(new MemoryUserRole
            {
                Name = "Administrators",
                Description = "System admins"
            });
            storage.Insert(new MemoryUserRole
            {
                Name = "Everyone",
                Description = "Public (un-authenticated) users"
            });
            storage.Insert(new MemoryUserRole
            {
                Name = "WebAdmins",
                Description = "Admins of web presentation"
            });
            storage.Insert(new MemoryUserRole
            {
                Name = "Articles",
                Description = "Article writers"
            });
        }
    }
}

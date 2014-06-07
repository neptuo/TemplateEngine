using Neptuo.Bootstrap;
using Neptuo.Lifetimes;
using Neptuo.TemplateEngine.Accounts;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Controllers.Commands;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Data.Entity.Queries;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Accounts.Controllers;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Templates.Compilation.Parsers;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Templates.DataSources;
using Neptuo.TemplateEngine.Web.ViewBundles;
using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using Neptuo.Templates.Compilation.Parsers;
using Neptuo.Validation;
using Neptuo.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Accounts.Templates.DataSources;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Security;
using Neptuo.Events;
using Neptuo.TemplateEngine.Accounts.Events;
using Neptuo.Events.Handlers;
using Neptuo.TemplateEngine.Security.Events;
using System.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Hosting.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Controllers.Validation;
using Neptuo.TemplateEngine.Hosting.Controllers;
using Neptuo.TemplateEngine.Hosting.DataSources;
using Neptuo.Commands.Execution;
using Neptuo.Commands.Interception;
using Neptuo.TemplateEngine.Hosting.Commands;
using Neptuo.TemplateEngine.Accounts.Commands.Handlers;

namespace Neptuo.TemplateEngine.Accounts.Hosting.Bootstrap
{
    [Module]
    public class AccountBootstrapTask : IBootstrapTask
    {
        private IDependencyContainer dependencyContainer;
        private TypeBuilderRegistry registry;
        private IWebDataSourceRegistry dataSourceRegistry;
        private CommandRegistryContext commandContext;

        public AccountBootstrapTask(IDependencyContainer dependencyContainer, TypeBuilderRegistry registry, CommandRegistryContext commandContext, IWebDataSourceRegistry dataSourceRegistry)
        {
            Guard.NotNull(dependencyContainer, "dependencyContainer");
            Guard.NotNull(registry, "registry");
            Guard.NotNull(dataSourceRegistry, "dataSourceRegistry");
            Guard.NotNull(commandContext, "commandContext");

            this.dependencyContainer = dependencyContainer;
            this.registry = registry;
            this.dataSourceRegistry = dataSourceRegistry;
            this.commandContext = commandContext;
        }

        public void Initialize()
        {
            SetupDependencyContainer(dependencyContainer);
            SetupTypeBuilderRegistry(registry);
            SetupControllers(commandContext);
            SetupDataSources(dataSourceRegistry);

            Database.SetInitializer(new DbInitializer());
//#if DEBUG
            //CreateDummyUserRoles();
            //CreateDummyUserAccounts();
//#endif
        }

        protected void SetupTypeBuilderRegistry(TypeBuilderRegistry registry)
        {
            registry.RegisterNamespace(new NamespaceDeclaration("data", "Neptuo.TemplateEngine.Accounts.Templates.DataSources, Neptuo.TemplateEngine.Accounts.Templates"));

            registry.RegisterComponentBuilder("ui", "AccountSideNav", new UserTemplateComponentBuilderFactory("~/Views/Accounts/SideNavUserControl.view"));
            registry.RegisterComponentBuilder("ui", "LoginView", new UserTemplateComponentBuilderFactory("~/Views/Accounts/LoginUserControl.view"));
        }

        protected void SetupDependencyContainer(IDependencyContainer dependencyContainer)
        {
            dependencyContainer
                .RegisterType<DataContext>(new PerRequestLifetime())

                .RegisterType<IAuthenticator, UserAccountService>()
                .RegisterType<IUserContext, CurrentUserContext>(new PerRequestLifetime())
                .RegisterType<IUserLogContext, CurrentUserContext>(new PerRequestLifetime())

                .RegisterType<IUserAccountRepository, EntityUserAccountRepository>(new PerRequestLifetime())
                .RegisterType<IUserAccountQuery, EntityUserAccountQuery>()
                .RegisterType<IActivator<UserAccount>, EntityUserAccountRepository>(new PerRequestLifetime())
                .RegisterActivator<IUserAccountQuery>(new PerRequestLifetime())
                .RegisterType<IValidator<UserAccountCreateCommand>, UserAccountValidator>()
                .RegisterType<IValidator<UserAccountEditCommand>, UserAccountValidator>()

                .RegisterType<IUserRoleRepository, EntityUserRoleRepository>(new PerRequestLifetime())
                .RegisterType<IUserRoleQuery, EntityUserRoleQuery>()
                .RegisterType<IActivator<UserRole>, EntityUserRoleRepository>(new PerRequestLifetime())
                .RegisterActivator<IUserRoleQuery>(new PerRequestLifetime())
                .RegisterType<IValidator<UserRoleCreateCommand>, UserRoleValidator>()
                .RegisterType<IValidator<UserRoleEditCommand>, UserRoleValidator>()

                .RegisterType<IUserLogRepository, EntityUserLogRepository>(new PerRequestLifetime())
                .RegisterType<IUserLogQuery, EntityUserLogQuery>(new PerRequestLifetime())
                .RegisterType<IActivator<UserLog>, EntityUserLogRepository>(new PerRequestLifetime())
                .RegisterActivator<IUserLogQuery>(new PerRequestLifetime())

                .RegisterType<IResourcePermissionRepository, EntityResourcePermissionRepository>(new PerRequestLifetime())
                .RegisterType<IResourcePermissionQuery, EntityResourcePermissionQuery>()
                .RegisterType<IActivator<ResourcePermission>, EntityResourcePermissionRepository>(new PerRequestLifetime())
                .RegisterActivator<IResourcePermissionQuery>(new PerRequestLifetime())

                ;
        }

        protected void SetupControllers(CommandRegistryContext commandContext)
        {
            ICommandExecutorFactory executorFactory = new DependencyCommandExecutorFactory(dependencyContainer, commandContext.InterceptorProvider);

            commandContext
                .AddCommand<UserLoginCommand, UserLoginCommandHandler>("Accounts/Login", dependencyContainer)
                .AddCommand<UserLogoutCommand, UserLogoutCommandHandler>("Accounts/Logout", dependencyContainer);

            commandContext.ControllerRegistry
                .Add(dependencyContainer, typeof(UserAccountController))
                .Add(dependencyContainer, typeof(UserRoleController))
                .Add(dependencyContainer, typeof(ResourcePermissionController));
        }

        protected void SetupDataSources(IWebDataSourceRegistry dataSourceRegistry)
        {
            dataSourceRegistry.AddFromAssembly(typeof(UserAccountDataSource).Assembly);
        }

        #region Init data

        //protected void CreateDummyUserAccounts()
        //{
        //    IUserRoleRepository userRoles = dependencyContainer.Resolve<IUserRoleRepository>();
        //    IUserAccountRepository storage = dependencyContainer.Resolve<IUserAccountRepository>();
        //    for (int i = 0; i < 34; i++)
        //    {
        //        storage.Insert(new MemoryUserAccount
        //        {
        //            Username = "User " + i,
        //            IsEnabled = (i % 3) == 1,
        //            Roles = new List<UserRole>
        //            {
        //                userRoles.Get(1),
        //                userRoles.Get(2)
        //            }
        //        });
        //    }
        //}

        //protected void CreateDummyUserRoles()
        //{
        //    IUserRoleRepository storage = dependencyContainer.Resolve<IUserRoleRepository>();
        //    storage.Insert(new MemoryUserRole
        //    {
        //        Name = "Administrators",
        //        Description = "System admins"
        //    });
        //    storage.Insert(new MemoryUserRole
        //    {
        //        Name = "Everyone",
        //        Description = "Public (un-authenticated) users"
        //    });
        //    storage.Insert(new MemoryUserRole
        //    {
        //        Name = "WebAdmins",
        //        Description = "Admins of web presentation"
        //    });
        //    storage.Insert(new MemoryUserRole
        //    {
        //        Name = "Articles",
        //        Description = "Article writers"
        //    });
        //}

        #endregion
    }
}

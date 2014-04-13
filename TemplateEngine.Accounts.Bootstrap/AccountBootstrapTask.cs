﻿using Neptuo.Bootstrap;
using Neptuo.Commands.Handlers;
using Neptuo.Lifetimes;
using Neptuo.TemplateEngine.Accounts;
using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Accounts.Commands.Handlers;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Data.Entity.Queries;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Accounts.Web.Controllers;
using Neptuo.TemplateEngine.Accounts.Web.DataSources;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Templates.Compilation.Parsers;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Web.DataSources;
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

namespace Neptuo.TemplateEngine.Accounts.Bootstrap
{
    [Module]
    public class AccountBootstrapTask : AccountBootstrapTaskBase, IBootstrapTask
    {
        private IDependencyContainer dependencyContainer;
        private TypeBuilderRegistry registry;
        private IFormUriRegistry formRegistry;
        private IControllerRegistry controllerRegistry;
        private GlobalNavigationCollection globalNavigations;
        private IWebDataSourceRegistry dataSourceRegistry;
        private IViewBundleCollection viewBundles;

        public AccountBootstrapTask(IDependencyContainer dependencyContainer, TypeBuilderRegistry registry, IFormUriRegistry formRegistry, IControllerRegistry controllerRegistry, GlobalNavigationCollection globalNavigations, IWebDataSourceRegistry dataSourceRegistry)
        {
            Guard.NotNull(dependencyContainer, "dependencyContainer");
            Guard.NotNull(registry, "registry");
            Guard.NotNull(formRegistry, "formRegistry");
            Guard.NotNull(controllerRegistry, "controllerRegistry");
            Guard.NotNull(globalNavigations, "globalNavigations");
            Guard.NotNull(dataSourceRegistry, "dataSourceRegistry");

            this.dependencyContainer = dependencyContainer;
            this.registry = registry;
            this.formRegistry = formRegistry;
            this.controllerRegistry = controllerRegistry;
            this.globalNavigations = globalNavigations;
            this.dataSourceRegistry = dataSourceRegistry;
            this.viewBundles = ViewBundleTable.Bundles;
        }

        public void Initialize()
        {
            SetupDependencyContainer(dependencyContainer);
            SetupTypeBuilderRegistry(registry);
            SetupControllers(controllerRegistry);
            SetupDataSources(dataSourceRegistry);

            SetupForms(formRegistry);
            SetupGlobalNavigations(globalNavigations);


//#if DEBUG
            //CreateDummyUserRoles();
            //CreateDummyUserAccounts();
//#endif
        }

        protected void SetupTypeBuilderRegistry(TypeBuilderRegistry registry)
        {
            registry.RegisterNamespace(new NamespaceDeclaration("data", "Neptuo.TemplateEngine.Accounts.Templates.DataSources, Neptuo.TemplateEngine.Accounts.Web"));

            registry.RegisterComponentBuilder("ui", "AccountSideNav", new UserTemplateComponentBuilderFactory("~/Views/Accounts/SideNav.view"));
        }

        protected void SetupDependencyContainer(IDependencyContainer dependencyContainer)
        {
            dependencyContainer
                .RegisterType<DataContext>(new PerRequestLifetime())

                .RegisterType<IUserAccountRepository, EntityUserAccountRepository>(new PerRequestLifetime())
                .RegisterType<IUserAccountQuery, EntityUserAccountQuery>()
                .RegisterType<IActivator<UserAccount>, EntityUserAccountRepository>(new PerRequestLifetime())

                .RegisterCommandHandler<UserAccountCreateCommand, UserAccountCreateCommandHandler>()
                .RegisterCommandHandler<UserAccountEditCommand, UserAccountEditCommandHandler>()
                .RegisterCommandHandler<UserAccountDeleteCommand, UserAccountDeleteCommandHandler>()

                .RegisterType<IUserRoleRepository, EntityUserRoleRepository>(new PerRequestLifetime())
                .RegisterType<IUserRoleQuery, EntityUserRoleQuery>()
                .RegisterType<IActivator<UserRole>, EntityUserRoleRepository>(new PerRequestLifetime())
                .RegisterCommandHandler<UserRoleEditCommand, EditUserRoleCommandHandler>()

                .RegisterType<IAuthenticator, UserAccountService>()


                .RegisterType<ICommandHandler<UserAccountCreateCommand>, UserAccountCreateHandler>()
                .RegisterType<ICommandHandler<UserAccountEditCommand>, UserAccountUpdateHandler>();
        }

        protected void SetupControllers(IControllerRegistry controllerRegistry)
        {
            controllerRegistry
                .Add(dependencyContainer, typeof(UserAccountController))
                .Add(dependencyContainer, typeof(UserRoleController))
                //.Add("Accounts/User/Create", new ModelControllerFactory<UserAccountCreateCommand>(dependencyContainer));
                .AddCommandHandlers(dependencyContainer, typeof(UserAccountCreateHandler).Assembly);
        }

        protected void SetupDataSources(IWebDataSourceRegistry dataSourceRegistry)
        {
            dataSourceRegistry.AddFromAssembly(typeof(UserAccountDataSource).Assembly);
        }

        #region Init data

        protected void CreateDummyUserAccounts()
        {
            IUserRoleRepository userRoles = dependencyContainer.Resolve<IUserRoleRepository>();
            IUserAccountRepository storage = dependencyContainer.Resolve<IUserAccountRepository>();
            for (int i = 0; i < 34; i++)
            {
                storage.Insert(new MemoryUserAccount
                {
                    Username = "User " + i,
                    IsEnabled = (i % 3) == 1,
                    Roles = new List<UserRole>
                    {
                        userRoles.Get(1),
                        userRoles.Get(2)
                    }
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

        #endregion
    }
}

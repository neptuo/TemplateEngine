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
                .RegisterType<IUserQuery, MemoryUserAccountRepository>(new SingletonLifetime())
                .RegisterType<IUserRoleRepository, UserRoleRepository>(new PerRequestLifetime())
                .RegisterType<IActivator<UserRole>, UserRoleRepository>(new PerRequestLifetime())
                .RegisterType<ICommandHandler<EditUserCommand>, EditUserCommandHandler>(new PerRequestLifetime())
                .RegisterType<IValidator<EditUserCommand>, EditUserCommandHandler>(new PerRequestLifetime());

            registry.RegisterNamespace(new NamespaceDeclaration("ui", "Neptuo.TemplateEngine.Accounts.Web.Presenters, Neptuo.TemplateEngine.Accounts.Web"));
            registry.RegisterNamespace(new NamespaceDeclaration("data", "Neptuo.TemplateEngine.Accounts.Web.DataSources, Neptuo.TemplateEngine.Accounts.Web"));

            formRegistry
                .Register("Accounts.User.List", TemplateRouteParameter.FormatUrl("~/Accounts/UserList"))
                .Register("Accounts.User.Edit", TemplateRouteParameter.FormatUrl("~/Accounts/UserEdit"));

            controllerRegistry
                .Add("User/Save", dependencyContainer, typeof(UserEditSaveController));

#if DEBUG
            CreateDummyUserAccounts();
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
    }
}

using Neptuo.Bootstrap;
using Neptuo.Lifetimes;
using Neptuo.TemplateEngine.Accounts;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Queries;
using Neptuo.TemplateEngine.Web;
using Neptuo.Templates.Compilation;
using Neptuo.Templates.Compilation.Parsers;
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

        public AccountBootstrapTask(IDependencyContainer dependencyContainer, TypeBuilderRegistry registry)
        {
            this.dependencyContainer = dependencyContainer;
            this.registry = registry;
        }

        public void Initialize()
        {
            dependencyContainer
                //.RegisterInstance<IAccountDbContext>()
                .RegisterType<IUserAccountRepository, UserAccountRepository>(new PerRequestLifetime())
                .RegisterType<IActivator<UserAccount>, UserAccountRepository>(new PerRequestLifetime())
                .RegisterType<IUserRoleRepository, UserRoleRepository>(new PerRequestLifetime())
                .RegisterType<IActivator<UserRole>, UserRoleRepository>(new PerRequestLifetime())
                .RegisterType<IUserQuery, UserAccountRepository>(new PerRequestLifetime());

            registry
                .RegisterNamespace(new NamespaceDeclaration("ui", "Neptuo.TemplateEngine.Accounts.Web.Controls, Neptuo.TemplateEngine.Accounts.Web"));
        }
    }
}

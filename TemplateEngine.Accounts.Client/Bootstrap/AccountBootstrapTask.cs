using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Web.Controllers;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Bootstrap
{
    public class AccountBootstrapTask : AccountBootstrapTaskBase, IBootstrapTask
    {
        private IDependencyContainer dependencyContainer;
        private IFormUriRegistry formRegistry;
        private IControllerRegistry controllerRegistry;
        private GlobalNavigationCollection globalNavigations;

        public AccountBootstrapTask(IDependencyContainer dependencyContainer, IFormUriRegistry formRegistry, IControllerRegistry controllerRegistry, GlobalNavigationCollection globalNavigations)
        {
            Guard.NotNull(dependencyContainer, "dependencyContainer");
            Guard.NotNull(formRegistry, "formRegistry");
            Guard.NotNull(controllerRegistry, "controllerRegistry");
            Guard.NotNull(globalNavigations, "globalNavigations");

            this.dependencyContainer = dependencyContainer;
            this.formRegistry = formRegistry;
            this.controllerRegistry = controllerRegistry;
            this.globalNavigations = globalNavigations;
        }

        public void Initialize()
        {
            dependencyContainer
                .RegisterInstance(new UserRepository());

            //controllerRegistry
            //    .Add("Accounts/User/Create", new DependencyControllerFactory(dependencyContainer, typeof(UserAccountController)));
                //.Add(dependencyContainer, typeof(UserAccountController));

            RegisterForms(formRegistry);
            RegisterGlobalNavigations(globalNavigations);
        }
    }
}

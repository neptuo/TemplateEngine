using Neptuo.Bootstrap;
using Neptuo.ComponentModel.Converters;
using Neptuo.TemplateEngine.Accounts.Controllers;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Controllers;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Providers;

namespace Neptuo.TemplateEngine.Accounts.Bootstrap
{
    public class AccountBootstrapTask : AccountBootstrapTaskBase, IBootstrapTask
    {
        private IDependencyContainer dependencyContainer;
        private IFormUriRegistry formRegistry;
        private IControllerRegistry controllerRegistry;
        private GlobalNavigationCollection globalNavigations;
        private IConverterRepository converterRepository;

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
            this.converterRepository = Converts.Repository;
        }

        public void Initialize()
        {
            //controllerRegistry
            //    .Add("Accounts/User/Create", new DependencyControllerFactory(dependencyContainer, typeof(UserAccountController)));
            //.Add(dependencyContainer, typeof(UserAccountController));

            converterRepository
                .Add(typeof(JsObject), typeof(UserAccountEditModel), new UserAccountEditModelConverter())
                .Add(typeof(JsObject), typeof(UserAccountListResult), new UserAccountListResultConverter())

                .Add(typeof(JsObject), typeof(UserRoleEditModel), new UserRoleEditModelConverter())
                .Add(typeof(JsObject), typeof(UserRoleListResult), new UserRoleListResultConverter())

                .Add(typeof(JsObject), typeof(UserLogListResult), new UserLogListResultConverter());

            SetupForms(formRegistry);
            SetupGlobalNavigations(globalNavigations);
        }
    }
}

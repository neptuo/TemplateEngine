using Neptuo.Bootstrap;
using Neptuo.ComponentModel.Converters;
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

namespace Neptuo.TemplateEngine.Accounts.Hosting.Bootstrap
{
    public class AccountBootstrapTask : IBootstrapTask
    {
        private IDependencyContainer dependencyContainer;
        private IAsyncControllerRegistry controllerRegistry;
        private IConverterRepository converterRepository;

        public AccountBootstrapTask(IDependencyContainer dependencyContainer, IAsyncControllerRegistry controllerRegistry)
        {
            Guard.NotNull(dependencyContainer, "dependencyContainer");
            Guard.NotNull(controllerRegistry, "controllerRegistry");

            this.dependencyContainer = dependencyContainer;
            this.controllerRegistry = controllerRegistry;
            this.converterRepository = Converts.Repository;
        }

        public void Initialize()
        {
            converterRepository
                .Add(typeof(JsObject), typeof(UserAccountEditModel), new UserAccountEditModelConverter())
                .Add(typeof(JsObject), typeof(UserAccountListResult), new UserAccountListResultConverter())

                .Add(typeof(JsObject), typeof(UserRoleEditModel), new UserRoleEditModelConverter())
                .Add(typeof(JsObject), typeof(UserRoleListResult), new UserRoleListResultConverter())

                .Add(typeof(JsObject), typeof(UserLogListResult), new UserLogListResultConverter())

                .Add(typeof(JsObject), typeof(ResourcePermissionListResult), new ResourcePermissionListResultConverter());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Providers;

namespace Neptuo.TemplateEngine.Hosting.Integration
{
    /// <summary>
    /// Enables customization for <see cref="HostedApplication"/>.
    /// </summary>
    public interface IApplicationBuilder
    {
        /// <summary>
        /// Enables type registration to root container.
        /// </summary>
        void RegisterTypes(IDependencyContainer dependencyContainer);

        /// <summary>
        /// Enables bootstrap task registration.
        /// </summary>
        void RegisterBootstrapTasks(IBootstrapTaskRegistry bootstrapper);

        /// <summary>
        /// Enables formUri registration.
        /// </summary>
        void RegisterForms(IFormUriRegistry formRegistry, ITemplateUrlFormatter formatter);

        /// <summary>
        /// Enables registration for global navigation rules.
        /// </summary>
        void RegisterGlobalNavigations(GlobalNavigationCollection globalNavigations);
    }
}

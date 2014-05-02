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
    public interface IApplicationBuilder
    {
        void RegisterTypes(IDependencyContainer dependencyContainer);
        void RegisterBootstrapTasks(IBootstrapTaskRegistry bootstrapper);

        void RegisterForms(IFormUriRegistry formRegistry, ITemplateUrlFormatter formatter);
        void RegisterGlobalNavigations(GlobalNavigationCollection globalNavigations);
    }
}

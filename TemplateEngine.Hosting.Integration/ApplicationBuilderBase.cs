using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Integration
{
    public class ApplicationBuilderBase : IApplicationBuilder
    {
        public virtual void RegisterTypes(IDependencyContainer dependencyContainer)
        { }

        public virtual void RegisterBootstrapTasks(IBootstrapTaskRegistry bootstrapper)
        { }

        public virtual void RegisterForms(IFormUriRegistry formRegistry, ITemplateUrlFormatter formatter)
        { }

        public virtual void RegisterGlobalNavigations(GlobalNavigationCollection globalNavigations)
        { }
    }
}

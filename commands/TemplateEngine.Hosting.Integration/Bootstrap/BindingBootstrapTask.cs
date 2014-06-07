using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Templates;
using Neptuo.TemplateEngine.Web;
using Neptuo.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Integration.Bootstrap
{
    /// <summary>
    /// Registers binding manager.
    /// </summary>
    public class BindingBootstrapTask : IBootstrapTask
    {
        private IDependencyContainer dependencyContainer;

        public BindingBootstrapTask(IDependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public void Initialize()
        {
            dependencyContainer
                .RegisterInstance<IValueConverterService>(new ValueConverterService())
                .RegisterType<IBindingManager, BindingManagerBase>()
                .RegisterType<DataContextStorage>(new PerRequestLifetime());
        }
    }
}

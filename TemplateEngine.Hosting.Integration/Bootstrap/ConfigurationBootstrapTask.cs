using Neptuo.Bootstrap;
using Neptuo.Configuration;
using Neptuo.TemplateEngine.Configuration;
using Neptuo.TemplateEngine.Hosting.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Integration
{
    public class ConfigurationBootstrapTask : IBootstrapTask
    {
        private IDependencyContainer dependencyContainer;

        public ConfigurationBootstrapTask(IDependencyContainer dependencyContainer)
        {
            Guard.NotNull(dependencyContainer, "dependencyContainer");
            this.dependencyContainer = dependencyContainer;
        }

        public void Initialize()
        {
            IConfigurationScopeRegistry registry = new ConfigurationScopeRegistry();
            registry.MapScope("Static", new EmptyConfigurationScope()); //TODO: Add Application

            dependencyContainer
                .RegisterInstance<IConfigurationScopeRegistry>(registry)
                .RegisterInstance<IConfiguration>(new ConfigurationBase(registry, new EmptyConfigurationScope()))
                .RegisterType<IApplicationConfiguration, ApplicationConfiguration>();
        }
    }
}

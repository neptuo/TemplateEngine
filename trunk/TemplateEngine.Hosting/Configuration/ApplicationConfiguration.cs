using Neptuo.Configuration;
using Neptuo.TemplateEngine.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Configuration
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        private IConfiguration configuration;

        public bool IsDebug
        {
            get { return configuration.GetProperty<IsDebugProperty>().Value; }
        }

        public ApplicationConfiguration(IConfiguration configuration)
        {
            Guard.NotNull(configuration, "configuration");
            this.configuration = configuration;
        }
    }
}

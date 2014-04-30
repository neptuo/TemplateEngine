using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Hosting.Integration
{
    public class HostedApplication : HttpApplication
    {
        private IApplicationBuilder builder;

        public HostedApplication(IApplicationBuilder builder)
        {
            Guard.NotNull(builder, "builder");
            this.builder = builder;
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            OnStart();
        }

        protected virtual void OnStart()
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.Bootstrap;

namespace Neptuo.TemplateEngine.Hosting.Integration
{
    public interface IApplicationBuilder
    {
        void RegisterTypes(IDependencyContainer dependencyContainer);
        void RegisterBootstrapTasks(IBootstrapTaskRegistry bootstrapper);
    }
}

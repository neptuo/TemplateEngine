using Neptuo.TemplateEngine.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Controllers
{
    public static class ControllerRegistryExtensions
    {
        public static IControllerRegistry Add<TCommand>(this IControllerRegistry controllerRegistry, string actionName)
        {
            return controllerRegistry.Add(actionName, new CommandDispatcherControllerFactory<TCommand>());
        }
    }
}

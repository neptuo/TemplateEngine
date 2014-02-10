using Neptuo.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    public static class ControllerRegistryExtensions
    {
        public static IControllerRegistry Add(this IControllerRegistry controllerRegistry, IDependencyContainer dependencyContainer, Type controllerType)
        {
            foreach (MethodInfo methodInfo in controllerType.GetMethods())
            {
                ActionAttribute action = ReflectionHelper.GetAttribute<ActionAttribute>(methodInfo);
                if (action != null)
                    controllerRegistry.Add(action.ActionName, dependencyContainer, controllerType);
            }
            return controllerRegistry;
        }


        public static IControllerRegistry Add(this IControllerRegistry controllerRegistry, string actionName, IDependencyContainer dependencyContainer, Type controllerType)
        {
            return controllerRegistry.Add(actionName, new DependencyControllerFactory(dependencyContainer, controllerType));
        }
    }
}

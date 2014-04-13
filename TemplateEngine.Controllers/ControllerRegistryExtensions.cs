using Neptuo.Commands.Handlers;
using Neptuo.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
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

        public static IControllerRegistry AddCommandHandlers(this IControllerRegistry controllerRegistry, IDependencyProvider dependencyProvider, Assembly assembly)
        {
            foreach (Type type in assembly.GetTypes())
            {
                ActionAttribute action = type.GetCustomAttribute<ActionAttribute>();
                if (action != null)
                    controllerRegistry.Add(action.ActionName, new ModelControllerFactory(dependencyProvider, GetCommandHandlerModel(type)));
            }

            return controllerRegistry;
        }

        private static Type GetCommandHandlerModel(Type handlerType)
        {
            foreach (Type interfaceType in handlerType.GetInterfaces())
            {
                if (interfaceType.GetGenericTypeDefinition() == typeof(ICommandHandler<>))
                    return interfaceType.GetGenericArguments()[0];
            }

            throw new NotSupportedException();
        }
    }
}

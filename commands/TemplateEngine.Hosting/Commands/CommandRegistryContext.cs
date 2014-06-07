using Neptuo.Commands.Execution;
using Neptuo.Commands.Handlers;
using Neptuo.Commands.Interception;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Hosting.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Commands
{
    public class CommandRegistryContext
    {
        public DispatchingCommandExecutorFactory ExecutorFactory { get; private set; }
        public IInterceptorProvider InterceptorProvider { get; private set; }
        public IControllerRegistry ControllerRegistry { get; private set; }

        public CommandRegistryContext(DispatchingCommandExecutorFactory commandExecutorFactory, IInterceptorProvider interceptorProvider, IControllerRegistry controllerRegistry)
        {
            ExecutorFactory = commandExecutorFactory;
            InterceptorProvider = interceptorProvider;
            ControllerRegistry = controllerRegistry;
        }

        public CommandRegistryContext AddCommand<TCommand, TCommandHandler>(string actionName, IDependencyContainer dependencyContainer)
        {
            ICommandExecutorFactory executorFactory = new DependencyCommandExecutorFactory(dependencyContainer, InterceptorProvider);
            ExecutorFactory.AddFactory(typeof(TCommand), executorFactory);
            ControllerRegistry.Add<TCommand>(actionName);
            dependencyContainer.RegisterType<ICommandHandler<TCommand>, TCommandHandler>();
            return this;
        }
    }
}

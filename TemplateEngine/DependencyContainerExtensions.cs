using Neptuo.Commands.Handlers;
using Neptuo.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine
{
    public static class DependencyContainerExtensions
    {
        public static IDependencyContainer RegisterCommandHandler<TCommand, TCommandHandler>(this IDependencyContainer dependencyContainer)
            where TCommandHandler : ICommandHandler<TCommand>, IValidator<TCommand>
        {
            return dependencyContainer
                .RegisterType<ICommandHandler<TCommand>, TCommandHandler>()
                .RegisterType<IValidator<TCommand>, TCommandHandler>();
        }
    }
}

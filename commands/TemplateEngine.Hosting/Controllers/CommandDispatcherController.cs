using Neptuo.Commands;
using Neptuo.TemplateEngine.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Controllers
{
    public class CommandDispatcherController : IController
    {
        private Type commandType;

        public CommandDispatcherController(Type commandType)
        {
            Guard.NotNull(commandType, "commandType");
            this.commandType = commandType;
        }

        public void Execute(IControllerContext context)
        {
            object command = context.ModelBinder.Bind(commandType);
            context.DependencyProvider.Resolve<ICommandDispatcher>().Handle(command);
        }
    }
}

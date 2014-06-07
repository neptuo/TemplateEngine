using Neptuo.TemplateEngine.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Controllers
{
    public class CommandDispatcherControllerFactory : IControllerFactory
    {
        private Type commandType;

        public CommandDispatcherControllerFactory(Type commandType)
        {
            Guard.NotNull(commandType, "commandType");
            this.commandType = commandType;
        }

        public IController Create()
        {
            return new CommandDispatcherController(commandType);
        }
    }

    public class CommandDispatcherControllerFactory<TCommand> : CommandDispatcherControllerFactory
    {
        public CommandDispatcherControllerFactory()
            : base(typeof(TCommand))
        { }
    }
}

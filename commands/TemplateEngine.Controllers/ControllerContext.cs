using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public class ControllerContext : IControllerContext
    {
        public string ActionName { get; private set; }
        public IModelBinder ModelBinder { get; private set; }
        public IDependencyProvider DependencyProvider { get; private set; }
        public string Navigation { get; set; }
        public MessageStorage Messages { get; private set; }

        public ControllerContext(string action, IModelBinder modelBinder, IDependencyProvider dependencyProvider, MessageStorage messages)
        {
            Guard.NotNull(action, "action");
            Guard.NotNull(modelBinder, "modelBinder");
            Guard.NotNull(dependencyProvider, "dependencyProvider");
            Guard.NotNull(messages, "messages");

            ActionName = action;
            ModelBinder = modelBinder;
            DependencyProvider = dependencyProvider;
            Messages = messages;
        }
    }
}

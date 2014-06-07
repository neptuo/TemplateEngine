using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public class AsyncControllerContext : IAsyncControllerContext
    {
        public string ActionName { get; private set; }
        public IParameterProvider Parameters { get; private set; }
        public IModelBinder ModelBinder { get; private set; }
        public IDependencyProvider DependencyProvider { get; private set; }
        public string Navigation { get; set; }
        public MessageStorage Messages { get; private set; }

        private Action onComplete;

        public AsyncControllerContext(string action, IParameterProvider parameters, IModelBinder modelBinder, IDependencyProvider dependencyProvider, MessageStorage messages, Action onComplete)
        {
            Guard.NotNull(action, "action");
            Guard.NotNull(parameters, "parameters");
            Guard.NotNull(modelBinder, "modelBinder");
            Guard.NotNull(dependencyProvider, "dependencyProvider");
            Guard.NotNull(messages, "messages");
            Guard.NotNull(onComplete, "onComplete");

            ActionName = action;
            Parameters = parameters;
            ModelBinder = modelBinder;
            DependencyProvider = dependencyProvider;
            Messages = messages;
            this.onComplete = onComplete;
        }

        public void OnComplete()
        {
            onComplete();
        }
    }
}

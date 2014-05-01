using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public class AsyncControllerRegistryBase : IAsyncControllerRegistry
    {
        protected Dictionary<string, IAsyncControllerFactory> Storage { get; private set; }

        public AsyncControllerRegistryBase()
        {
            Storage = new Dictionary<string, IAsyncControllerFactory>();
        }

        public IAsyncControllerRegistry Add(string actionName, IAsyncControllerFactory factory)
        {
            Guard.NotNull(actionName, "actionName");
            Guard.NotNull(factory, "factory");

            Storage[actionName] = factory;
            return this;
        }

        public bool TryGet(string actionName, out IAsyncController controller)
        {
            Guard.NotNull(actionName, "actionName");
            IAsyncControllerFactory factory;
            if (Storage.TryGetValue(actionName, out factory))
            {
                controller = factory.Create();
                return true;
            }

            controller = null;
            return false;
        }
    }
}

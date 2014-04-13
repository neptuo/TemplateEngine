using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public class ControllerRegistryBase : IControllerRegistry
    {
        protected Dictionary<string, IControllerFactory> Storage { get; private set; }
        protected Dictionary<string, IAsyncControllerFactory> AsyncStorage { get; private set; }

        public ControllerRegistryBase()
        {
            Storage = new Dictionary<string, IControllerFactory>();
            AsyncStorage = new Dictionary<string, IAsyncControllerFactory>();
        }

        public IControllerRegistry Add(string actionName, IControllerFactory factory)
        {
            Guard.NotNull(actionName, "actionName");
            Guard.NotNull(factory, "factory");

            Storage[actionName] = factory;
            return this;
        }

        public IControllerRegistry Add(string actionName, IAsyncControllerFactory factory)
        {
            Guard.NotNull(actionName, "actionName");
            Guard.NotNull(factory, "factory");

            AsyncStorage[actionName] = factory;
            return this;
        }

        public bool TryGet(string actionName, out IController controller)
        {
            Guard.NotNull(actionName, "actionName");
            IControllerFactory factory;
            if (Storage.TryGetValue(actionName, out factory))
            {
                controller = factory.Create();
                return true;
            }

            controller = null;
            return false;
        }


        public bool TryGetAsync(string actionName, out IAsyncController controller)
        {
            Guard.NotNull(actionName, "actionName");
            IAsyncControllerFactory factory;
            if (AsyncStorage.TryGetValue(actionName, out factory))
            {
                controller = factory.Create();
                return true;
            }

            controller = null;
            return false;
        }
    }
}

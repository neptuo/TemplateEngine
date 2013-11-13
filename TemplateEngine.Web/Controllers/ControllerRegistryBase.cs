using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    public class ControllerRegistryBase : IControllerRegistry
    {
        protected Dictionary<string, IControllerFactory> Storage { get; private set; }

        public ControllerRegistryBase()
        {
            Storage = new Dictionary<string, IControllerFactory>();
        }

        public IControllerRegistry Add(string eventName, IControllerFactory factory)
        {
            if (eventName == null)
                throw new ArgumentNullException("eventName");

            if (factory == null)
                throw new ArgumentNullException("factory");

            Storage[eventName] = factory;
            return this;
        }

        public bool TryGet(string eventName, out IController handler)
        {
            if (eventName == null)
                throw new ArgumentNullException("eventName");

            IControllerFactory factory;
            if (Storage.TryGetValue(eventName, out factory))
            {
                handler = factory.Create();
                return true;
            }

            handler = null;
            return false;
        }
    }
}

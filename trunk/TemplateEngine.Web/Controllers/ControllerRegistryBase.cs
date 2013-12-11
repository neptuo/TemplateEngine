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

        public IControllerRegistry Add(string actionName, IControllerFactory factory)
        {
            if (actionName == null)
                throw new ArgumentNullException("actionName");

            if (factory == null)
                throw new ArgumentNullException("factory");

            Storage[actionName] = factory;
            return this;
        }

        public bool TryGet(string actionName, out IController handler)
        {
            if (actionName == null)
                throw new ArgumentNullException("actionName");

            IControllerFactory factory;
            if (Storage.TryGetValue(actionName, out factory))
            {
                handler = factory.Create();
                return true;
            }

            handler = null;
            return false;
        }
    }
}

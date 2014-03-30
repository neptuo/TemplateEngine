using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class SelectControlContext
    {
        public IComponentManager ComponentManager { get; private set; }
        public TemplateContentStorageStack Storage { get; private set; }
        public DataContextStorage DataContext { get; private set; }
        public IBindingManager BindingManager { get; private set; }

        public SelectControlContext(IComponentManager componentManager, TemplateContentStorageStack storage, DataContextStorage dataContext, IBindingManager bindingManager)
        {
            ComponentManager = componentManager;
            Storage = storage;
            DataContext = dataContext;
            BindingManager = bindingManager;
        }
    }
}

using Neptuo.TemplateEngine.Providers;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class SelectControlContext
    {
        public IRequestContext RequestContext { get; private set; }
        public TemplateContentStorageStack Storage { get; private set; }
        public DataContextStorage DataContext { get; private set; }
        public IBindingManager BindingManager { get; private set; }

        public SelectControlContext(IRequestContext requestContext, TemplateContentStorageStack storage, DataContextStorage dataContext, IBindingManager bindingManager)
        {
            RequestContext = requestContext;
            Storage = storage;
            DataContext = dataContext;
            BindingManager = bindingManager;
        }
    }
}

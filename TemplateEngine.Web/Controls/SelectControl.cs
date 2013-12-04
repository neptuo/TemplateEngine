using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class SelectControl : ListViewControl
    {
        public object Value { get; set; }

        public SelectControl(IComponentManager componentManager, TemplateContentStorageStack storage, DataContextStorage dataContext)
            : base(componentManager, storage, dataContext)
        { }
    }
}

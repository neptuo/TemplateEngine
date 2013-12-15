using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class SelectControl : ListViewControl, IHtmlAttributeCollection, IAttributeCollection
    {
        public object Value { get; set; }
        public bool IsAddEmpty { get; set; }
        public HtmlAttributeCollection Attributes { get; private set; }

        public SelectControl(IComponentManager componentManager, TemplateContentStorageStack storage, DataContextStorage dataContext)
            : base(componentManager, storage, dataContext)
        {
            Attributes = new HtmlAttributeCollection();
        }

        public void SetAttribute(string name, string value)
        {
            Attributes[name] = value;
        }
    }
}

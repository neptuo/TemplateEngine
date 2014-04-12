using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class TemplatePlaceholder : IControl
    {
        protected TemplateContentStorageStack Contents { get; private set; }
        public string Name { get; set; }

        public TemplatePlaceholder(TemplateContentStorageStack contents)
        {
            Contents = contents;
        }

        public void OnInit()
        {
            if (Name == null)
                Name = String.Empty;
        }

        public void Render(IHtmlWriter writer)
        {
            TemplateContentStorage storage = Contents.Peek();
            if (storage.ContainsKey(Name))
                storage.Get(Name).Render(writer);
        }
    }
}

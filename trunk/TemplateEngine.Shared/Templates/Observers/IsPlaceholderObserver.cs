using Neptuo.Templates;
using Neptuo.Templates.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Observers
{
    public class IsPlaceholderObserver : IObserver
    {
        public string IsPlaceholder { get; set; }

        protected TemplateContentStorageStack TemplateStorage { get; private set; }

        public IsPlaceholderObserver(TemplateContentStorageStack templateStorage)
        {
            TemplateStorage = templateStorage;
        }

        public void OnInit(ObserverEventArgs e)
        {
            if (!TemplateStorage.Peek().ContainsKey(IsPlaceholder))
                e.Cancel = true;
        }

        public void Render(ObserverEventArgs e, IHtmlWriter writer)
        {
            if (!TemplateStorage.Peek().ContainsKey(IsPlaceholder))
                e.Cancel = true;
        }
    }
}

using Neptuo.Templates;
using Neptuo.Templates.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Observers
{
    public class VisibleObserver : IObserver
    {
        public bool IsVisible { get; set; }

        public void OnInit(ObserverEventArgs e)
        {
            if (!IsVisible)
                e.Cancel = true;
        }

        public void Render(ObserverEventArgs e, IHtmlWriter writer)
        {
            if (!IsVisible)
                e.Cancel = true;
        }
    }
}

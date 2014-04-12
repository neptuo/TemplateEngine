using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using Neptuo.Templates.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Web;

namespace Neptuo.TemplateEngine.Web.Observers
{
    public class EventObserver : IObserver
    {
        public string Event { get; set; }

        public void OnInit(ObserverEventArgs e)
        {
            ButtonControl button = e.Target as ButtonControl;
            if (button == null)
                throw new InvalidOperationException("EventObserver must used on ButtonControl.");

            if (String.IsNullOrEmpty(button.Name))
                button.Name = Event;
        }

        public void Render(ObserverEventArgs e, IHtmlWriter writer)
        { }
    }
}

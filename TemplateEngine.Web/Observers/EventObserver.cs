using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using Neptuo.Templates.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web.Observers
{
    public class EventObserver : IObserver
    {
        protected HttpContextBase HttpContext { get; private set; }
        //protected IEventHandler EventHandler { get; private set; }
        public string Event { get; set; }

        public EventObserver(HttpContextBase httpContext/*, IEventHandler eventHandler*/)
        {
            HttpContext = httpContext;
            //EventHandler = eventHandler;
        }

        public void OnInit(ObserverEventArgs e)
        {
            ButtonControl button = e.Target as ButtonControl;
            if (button == null)
                throw new InvalidOperationException("EventObserver must used on ButtonControl.");

            if (String.IsNullOrEmpty(button.Name))
                button.Name = Event;
            //throw new InvalidOperationException("ButtonControl must have a name.");

            //if (HttpContext.Request.Form.AllKeys.Contains(button.Name))
            //    EventHandler.Publish(Event, new EventHandlerEventArgs(Event));
        }

        public void Render(ObserverEventArgs e, IHtmlWriter writer)
        { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public interface IEventHandler
    {
        void Subscribe(string eventName, Action<EventHandlerEventArgs> handler);
        void Publish(string eventName, EventHandlerEventArgs args);
    }

    public class SimpleEventHandler : IEventHandler
    {
        private Dictionary<string, Action<EventHandlerEventArgs>> handlers = new Dictionary<string, Action<EventHandlerEventArgs>>();

        public void Subscribe(string eventName, Action<EventHandlerEventArgs> handler)
        {
            if (eventName == null)
                throw new ArgumentNullException("eventName");

            if (handler == null)
                throw new ArgumentNullException("handler");

            handlers[eventName] = handler;
        }

        public void Publish(string eventName, EventHandlerEventArgs args)
        {
            Action<EventHandlerEventArgs> handler;
            if (handlers.TryGetValue(eventName, out handler))
                handler(args);
        }
    }


    public class EventHandlerEventArgs : EventArgs
    {
        public string EventName { get; private set; }

        public EventHandlerEventArgs(string eventName)
        {
            EventName = eventName;
        }
    }
}

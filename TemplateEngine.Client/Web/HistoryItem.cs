using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class HistoryItem
    {
        public string Url { get; private set; }
        public JsArray FormData { get; private set; }
        public string EventName { get; private set; }

        public HistoryItem(string url, FormRequestContext context)
        {
            Url = url;
            if (context != null)
            {
                FormData = context.Parameters;
                EventName = context.EventName;
            }
        }

        public HistoryItem(string url, JsArray formData, string eventName)
        {
            Url = url;
            FormData = formData;
            EventName = eventName;
        }
    }
}

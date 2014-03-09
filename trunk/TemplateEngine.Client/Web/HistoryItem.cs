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
        public string[] ToUpdate { get; private set; }
        public string Url { get; private set; }
        public JsArray FormData { get; private set; }
        public string EventName { get; private set; }

        public HistoryItem(string url, string[] toUpdate, FormRequestContext context = null)
        {
            Url = url;
            ToUpdate = toUpdate;
            if (context != null)
            {
                FormData = context.Parameters;
                EventName = context.EventName;
            }
        }
    }
}

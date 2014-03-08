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
        public FormRequestContext FormData { get; private set; }

        public HistoryItem(string url, FormRequestContext formData)
        {
            Url = url;
            FormData = formData;
        }
    }
}

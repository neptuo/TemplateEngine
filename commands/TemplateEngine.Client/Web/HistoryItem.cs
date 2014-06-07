using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Single history state item.
    /// </summary>
    public class HistoryItem
    {
        /// <summary>
        /// Regions to update.
        /// </summary>
        public string[] ToUpdate { get; private set; }

        /// <summary>
        /// Url.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Associated form data.
        /// </summary>
        public JsArray FormData { get; private set; }

        public HistoryItem(string url, string[] toUpdate, FormRequestContext context = null)
        {
            Url = url;
            ToUpdate = toUpdate;
            if (context != null)
                FormData = context.Parameters;
        }
    }
}

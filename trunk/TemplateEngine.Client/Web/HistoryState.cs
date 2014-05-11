using SharpKit.Html;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// History API implementation of <see cref="IHistoryState"/>.
    /// </summary>
    public class HistoryState : IHistoryState
    {
        private bool isPopAssigned = false;
        private event Action<HistoryItem> onPop;

        public event Action<HistoryItem> OnPop
        {
            add
            {
                onPop += value;
                if (onPop != null && !isPopAssigned)
                {
                    HtmlContext.window.addEventListener("popstate", OnPopState);
                    isPopAssigned = true;
                }
            }
            remove
            {
                onPop -= value;
                if (onPop == null && isPopAssigned)
                {
                    HtmlContext.window.removeEventListener("popstate", OnPopState);
                    isPopAssigned = false;
                }
            }
        }

        private void OnPopState(DOMEvent e)
        {
            PopStateEvent state = e.As<PopStateEvent>();
            HistoryItem historyItem = state.state.As<HistoryItem>();

            if (onPop != null)
                onPop(historyItem);
        }

        public void Push(HistoryItem item)
        {
            HtmlContext.history.pushState(item, "", item.Url);
        }

        public void Replace(HistoryItem item)
        {
            HtmlContext.history.replaceState(item, "", item.Url);
        }
    }
}

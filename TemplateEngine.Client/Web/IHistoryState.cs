using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public interface IHistoryState
    {
        event Action<HistoryItem> OnPop;

        void Push(HistoryItem item);
        void Replace(HistoryItem item);
    }
}

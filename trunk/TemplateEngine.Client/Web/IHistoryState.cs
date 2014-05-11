using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Maintains history and browser url state.
    /// </summary>
    public interface IHistoryState
    {
        /// <summary>
        /// When user goes backward or forward.
        /// </summary>
        event Action<HistoryItem> OnPop;

        /// <summary>
        /// Adds new <see cref="HistoryItem"/>.
        /// </summary>
        /// <param name="item">New history item.</param>
        void Push(HistoryItem item);

        /// <summary>
        /// Rewrites current <see cref="HistoryItem"/>.
        /// </summary>
        /// <param name="item">New history item to rewite current.</param>
        void Replace(HistoryItem item);
    }
}

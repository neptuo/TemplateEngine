using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public interface IApplication
    {
        /// <summary>
        /// Name of default region to update.
        /// </summary>
        string[] DefaultToUpdate { get; }

        /// <summary>
        /// Provides access to application history state.
        /// </summary>
        IHistoryState HistoryState { get; }
    }
}

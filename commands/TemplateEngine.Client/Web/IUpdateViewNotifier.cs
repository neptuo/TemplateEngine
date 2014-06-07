using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Helps maintaining "Loading" state.
    /// </summary>
    public interface IUpdateViewNotifier
    {
        /// <summary>
        /// Start view update starts.
        /// </summary>
        void StartUpdate();

        /// <summary>
        /// End view update.
        /// </summary>
        void EndUpdate();
    }
}

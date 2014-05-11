using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Helps maintaing "Loading" view.
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

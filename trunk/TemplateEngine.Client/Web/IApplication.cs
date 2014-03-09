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
        /// Gets current root app path.
        /// </summary>
        /// <example>
        /// /App/ThisApp
        /// </example>
        string ApplicationPath { get; }

        /// <summary>
        /// Name of default region to update.
        /// </summary>
        string[] DefaultToUpdate { get; }

        /// <summary>
        /// Provides access to application history state.
        /// </summary>
        IHistoryState HistoryState { get; }

        /// <summary>
        /// Provides access to whole user interface.
        /// </summary>
        IMainView MainView { get; }

        /// <summary>
        /// Root dependecy container.
        /// </summary>
        IDependencyContainer DependencyContainer { get; }
    }
}

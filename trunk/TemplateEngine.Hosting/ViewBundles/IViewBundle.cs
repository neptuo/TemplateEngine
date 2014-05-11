using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.ViewBundles
{
    /// <summary>
    /// Defines bundle for views and scripts.
    /// </summary>
    public interface IViewBundle
    {
        /// <summary>
        /// Bundle name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Adds view path to bundle.
        /// </summary>
        /// <param name="viewPath">New view path.</param>
        void AddView(string viewPath);

        /// <summary>
        /// Adds script path to bundle.
        /// </summary>
        /// <param name="scriptPath">New string path.</param>
        void AddScript(string scriptPath);

        /// <summary>
        /// Enuamerates all registered views.
        /// </summary>
        IEnumerable<string> EnumerateViews();

        /// <summary>
        /// Enumerates all registered scripts.
        /// </summary>
        IEnumerable<string> EnumerateScripts();

        /// <summary>
        /// Returns true if contains <paramref name="viewPath"/>.
        /// </summary>
        /// <param name="viewPath">View path.</param>
        /// <returns>True if contains <paramref name="viewPath"/>.</returns>
        bool ContainsView(string viewPath);

        /// <summary>
        /// Returns true if contains <paramref name="scriptPath"/>.
        /// </summary>
        /// <param name="scriptPath">Script path.</param>
        /// <returns>True if contains <paramref name="scriptPath"/>.</returns>
        bool ContainsScript(string scriptPath);
    }
}

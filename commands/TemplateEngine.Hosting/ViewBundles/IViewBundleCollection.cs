using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.ViewBundles
{
    /// <summary>
    /// Collection of bundles.
    /// </summary>
    public interface IViewBundleCollection
    {
        /// <summary>
        /// Adds view bundle.
        /// </summary>
        /// <param name="bundle">New view bundle.</param>
        void Add(IViewBundle bundle);

        /// <summary>
        /// Tries get view bundle with <paramref name="name"/>.
        /// </summary>
        /// <param name="name">View bundle name.</param>
        /// <param name="bundle">View bundle.</param>
        /// <returns>True if there is registered view bundle with name <paramref name="name"/>.</returns>
        bool TryGet(string name, out IViewBundle bundle);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public interface IViewLoadedChecker
    {
        /// <summary>
        /// Checks if view for <paramref name="viewPath"/> is loaded.
        /// </summary>
        /// <param name="viewPath">View path.</param>
        /// <returns>True if view for <paramref name="viewPath"/> is loaded.</returns>
        bool IsViewLoaded(string viewPath);
    }
}

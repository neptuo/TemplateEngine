using Neptuo.TemplateEngine.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    /// <summary>
    /// Routes to static template url.
    /// </summary>
    public class StaticTemplateRoute : TemplateRoute
    {
        /// <summary>
        /// Real url (can be seen in browser).
        /// </summary>
        public string RealUrl { get; private set; }

        /// <summary>
        /// Url that will be rendere render.
        /// </summary>
        public string VirtualUrl { get; private set; }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="realUrl">Real url (can be seen in browser).</param>
        /// <param name="virtualUrl">Url that will be rendere render.</param>
        /// <param name="urlSuffix">Url suffix for <see cref="TemplateRoute"/>.</param>
        /// <param name="application">Applcation instance.</param>
        public StaticTemplateRoute(string realUrl, string virtualUrl, string urlSuffix, IApplication application)
            : base(urlSuffix, application)
        {
            RealUrl = realUrl;
            VirtualUrl = virtualUrl;
        }

        /// <summary>
        /// Maps request for <see cref="RealUrl"/> to <see cref="VirtualUrl"/>.
        /// </summary>
        public override string MapView(string url)
        {
            if (Application.ApplicationPath.Length > 1 && url.StartsWith(Application.ApplicationPath))
                url = url.Substring(Application.ApplicationPath.Length);

            if (url == RealUrl)
                return base.MapView(Application.ResolveUrl(VirtualUrl));

            return null;
        }
    }
}

using Neptuo.TemplateEngine.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public class StaticTemplateRoute : TemplateRoute
    {
        public string RealUrl { get; private set; }
        public string VirtualUrl { get; private set; }

        public StaticTemplateRoute(string realUrl, string virtualUrl, string urlSuffix, IApplication application)
            : base(urlSuffix, application)
        {
            RealUrl = realUrl;
            VirtualUrl = virtualUrl;
        }

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

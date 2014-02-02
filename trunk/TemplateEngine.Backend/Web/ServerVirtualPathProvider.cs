using Neptuo.TemplateEngine.Web;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Backend.Web
{
    public class ServerVirtualPathProvider : IVirtualPathProvider, IVirtualUrlProvider, ICurrentUrlProvider
    {
        public string MapPath(string path)
        {
            if (HttpContext.Current == null)
                throw new InvalidOperationException("ServerVirtualPathProvider can be used only from http request (using HttpContext.Current).");

            if (!path.StartsWith("~"))
                return path;

            return HttpContext.Current.Server.MapPath(path);
        }

        public string ResolveUrl(string path)
        {
            return VirtualPathUtility.ToAbsolute(path);
        }

        public string GetCurrentUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }
    }
}

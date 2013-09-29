using Neptuo.Web.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Backend.Web.Routing
{
    public class TemplateRouteParameter : IRouteParameter
    {
        public const string TemplateUrlSuffix = ".aspx";
        public const string TemplatePathSuffix = ".html";

        private HttpContextBase httpContext;

        public TemplateRouteParameter(HttpContextBase httpContext)
        {
            this.httpContext = httpContext;
        }

        public bool MatchUrl(IRouteParameterMatchContext context)
        {
            if (!context.OriginalUrl.EndsWith(TemplateUrlSuffix))
                return false;

            string templateUrl = Path.Combine(
                "~/",
                "Views",
                context.OriginalUrl.Replace(TemplateUrlSuffix, TemplatePathSuffix)
            );

            if (File.Exists(httpContext.Server.MapPath(templateUrl)))
            {
                context.Values["TemplateUrl"] = templateUrl;
                context.RemainingUrl = TemplateUrlSuffix;
                return true;
            }

            return false;
        }
    }
}

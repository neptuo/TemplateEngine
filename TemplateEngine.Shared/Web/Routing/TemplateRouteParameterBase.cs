using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Routing
{
    public class TemplateRouteParameterBase
    {
        public const string TemplateUrlSuffix = ".aspx";
        public const string TemplatePathSuffix = ".view";

        public static string FormatUrl(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");

            return String.Format("{0}{1}", path, TemplateUrlSuffix);
        }
    }
}

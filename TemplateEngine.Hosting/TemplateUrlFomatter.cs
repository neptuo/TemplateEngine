using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Web.Routing;

namespace Neptuo.TemplateEngine.Hosting
{
    public class TemplateUrlFomatter : ITemplateUrlFormatter
    {
        public string FormatUrl(string urlPart)
        {
            return TemplateRouteParameterBase.FormatUrl(urlPart);
        }
    }
}

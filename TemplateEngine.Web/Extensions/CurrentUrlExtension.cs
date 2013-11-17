using Neptuo.Templates.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web.Extensions
{
    public class CurrentUrlExtension : IValueExtension
    {
        private HttpRequestBase httpRequest;

        public CurrentUrlExtension(HttpRequestBase httpRequest)
        {
            this.httpRequest = httpRequest;
        }

        public object ProvideValue(IValueExtensionContext context)
        {
            return httpRequest.RawUrl;
        }
    }
}

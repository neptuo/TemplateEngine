using Neptuo.ComponentModel;
using Neptuo.Templates.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Templates.Extensions
{
    /// <summary>
    /// Tries to determine whether javascript processing is supported.
    /// </summary>
    [ReturnType(typeof(bool))]
    public class IsJavascriptEngineSupportedExtension : IValueExtension
    {
        private readonly HttpContextBase httpContext;

        public IsJavascriptEngineSupportedExtension(HttpContextBase httpContext)
        {
            Guard.NotNull(httpContext, "httpContext");
            this.httpContext = httpContext;
        }

        public object ProvideValue(IValueExtensionContext context)
        {
            bool result = true;

            if (httpContext.Request.Browser.Browser == "InternetExplorer" || httpContext.Request.Browser.Browser == "IE")
                return httpContext.Request.Browser.MajorVersion >= 9;
            
            return result;
        }
    }
}

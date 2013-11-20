using Neptuo.ComponentModel;
using Neptuo.Templates.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web.Extensions
{
    [DefaultProperty("Key")]
    public class RequestExtension : IValueExtension
    {
        private HttpRequestBase httpRequest;

        public string Key { get; set; }

        public RequestExtension(HttpRequestBase httpRequest)
        {
            this.httpRequest = httpRequest;
        }

        [ReturnType(typeof(string))]
        public object ProvideValue(IValueExtensionContext context)
        {
            if (Key == null)
                throw new ArgumentOutOfRangeException("Key", "Missing key.");

            return httpRequest.Params[Key];
        }
    }
}

using Neptuo.ComponentModel;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Web;
using Neptuo.Templates.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Extensions
{
    [DefaultProperty("Key")]
    public class RequestExtension : IValueExtension
    {
        private IParameterProvider parameterProvider;

        public string Key { get; set; }
        public object Default { get; set; }

        public RequestExtension(IParameterProvider parameterProvider)
        {
            this.parameterProvider = parameterProvider;
        }

        [ReturnType(typeof(string))]
        public object ProvideValue(IValueExtensionContext context)
        {
            Guard.NotNullOrEmpty(Key, "Key");

            object value;
            if (parameterProvider.TryGet(Key, out value))
                return value;

            return Default;
        }
    }
}

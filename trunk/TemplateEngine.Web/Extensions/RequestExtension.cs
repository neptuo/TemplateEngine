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
            if (Key == null)
                throw new ArgumentOutOfRangeException("Key", "Missing key.");

            object value;
            if (parameterProvider.TryGet(Key, out value))
                return value;

            return Default;
        }
    }
}

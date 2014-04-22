using Neptuo.ComponentModel;
using Neptuo.Templates.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Extensions
{
    [DefaultProperty("Format")]
    [ReturnType(typeof(string))]
    public class FormatStringExtension : IValueExtension
    {
        public string Format { get; set; }
        public object Value { get; set; }

        public object ProvideValue(IValueExtensionContext context)
        {
            if (String.IsNullOrEmpty(Format))
                Format = "{0}";
            else
                Format = Format.Replace("[0]", "{0}");

            return String.Format(Format, Value);
        }
    }
}

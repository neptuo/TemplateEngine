using Neptuo.Templates.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Extensions
{
    [DefaultProperty("Expression")]
    public class SwitchExtension : IValueExtension
    {
        protected IValueConverterService ConverterService { get; private set; }
        
        public object Expression { get; set; }
        public string ConverterKey { get; set; }
        public object TrueValue { get; set; }
        public object FalseValue { get; set; }

        public SwitchExtension(IValueConverterService converterService)
        {
            ConverterService = converterService;
        }

        public object ProvideValue(IValueExtensionContext context)
        {
            if (!String.IsNullOrEmpty(ConverterKey))
                Expression = ConverterService.GetConverter(ConverterKey).ConvertTo(Expression);

            bool? value = Expression as bool?;
            if (value == null)
                return TrueValue ?? FalseValue;

            if (value.Value)
                return TrueValue;

            return FalseValue;
        }
    }
}

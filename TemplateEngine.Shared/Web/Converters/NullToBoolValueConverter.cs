using Neptuo.ComponentModel;
using Neptuo.TemplateEngine.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Converters
{
    public class NullToBoolValueConverter : IValueConverter
    {
        [ReturnType(typeof(bool))]
        public object ConvertTo(object value)
        {
            return value != null;
        }
    }
}

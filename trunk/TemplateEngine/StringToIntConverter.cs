using Neptuo.ComponentModel.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine
{
    public class StringToIntConverter : ConverterBase<string, int>
    {
        public override bool TryConvert(string sourceValue, out int targetValue)
        {
            return Int32.TryParse(sourceValue, out targetValue);
        }
    }
}

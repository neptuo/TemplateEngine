using Neptuo.ComponentModel.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine
{
    /// <summary>
    /// Converter between string and int.
    /// </summary>
    public class StringToIntConverter : ConverterBase<string, int>
    {
        /// <summary>
        /// Uses <see cref="Int32.TryParse"/> as converter function.
        /// </summary>
        public StringToIntConverter()
            : base(Int32.TryParse)
        { }
    }
}

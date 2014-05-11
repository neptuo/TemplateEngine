using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    /// <summary>
    /// Converts used by <paramref name="BindingExtension"/>.
    /// </summary>
    public interface IValueConverter
    {
        object ConvertTo(object value);
    }
}

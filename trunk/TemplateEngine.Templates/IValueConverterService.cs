using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    /// <summary>
    /// List of registered <see cref="IValueConverter"/>.
    /// </summary>
    public interface IValueConverterService
    {
        IValueConverter GetConverter(string key);
        IValueConverterService SetConverter(string key, IValueConverter converter);
    }
}

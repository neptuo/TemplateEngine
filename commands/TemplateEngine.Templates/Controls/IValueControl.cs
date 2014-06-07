using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Represents control with Value property.
    /// </summary>
    public interface IValueControl
    {
        object Value { get; set; }
    }
}

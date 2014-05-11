using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Represents named form item.
    /// </summary>
    public interface IFormControl
    {
        string Name { get; set; }
    }
}

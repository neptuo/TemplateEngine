using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Simple placeholder.
    /// Create no content by it self.
    /// </summary>
    public class Placeholder : ContentControlBase
    {
        public Placeholder(IComponentManager componentManager)
            : base(componentManager)
        { }
    }
}

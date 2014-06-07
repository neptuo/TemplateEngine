using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Single parameter.
    /// </summary>
    public class ParameterControl : IControl, IValueControl
    {
        /// <summary>
        /// Parameter name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Parameter value.
        /// </summary>
        public object Value { get; set; }

        public void OnInit() 
        { }

        public void Render(IHtmlWriter writer)
        { }
    }
}

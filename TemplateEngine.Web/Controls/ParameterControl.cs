using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class ParameterControl : IControl, IValueControl
    {
        public string Name { get; set; }
        public object Value { get; set; }

        public void OnInit() 
        { }

        public void Render(IHtmlWriter writer)
        { }
    }
}

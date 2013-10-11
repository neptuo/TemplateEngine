using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    [Html("input")]
    public class HiddenBoxControl : BaseControl, IFormControl, ITextControl
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public HiddenBoxControl(IComponentManager componentManager)
            : base(componentManager)
        {
            Attributes["type"] = "hidden";
        }

        public void HandleValue(string value)
        {
            Text = value;
        }
    }
}

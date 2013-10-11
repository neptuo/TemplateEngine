using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    [Html("input")]
    public class TextBoxControl : BaseControl, ITextControl, IFormControl
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public TextBoxControl(IComponentManager componentManager)
            : base(componentManager)
        {
            Attributes["type"] = "text";
        }

        public override void Render(IHtmlWriter writer)
        {
            Attributes["value"] = Text;
            Attributes["name"] = Name;
            base.Render(writer);
        }

        public void HandleValue(string value)
        {
            Text = value;
        }
    }
}

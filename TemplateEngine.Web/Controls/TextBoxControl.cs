using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class TextBoxControl : FormInputControlBase, ITextControl
    {
        public string Text { get; set; }

        public TextBoxControl(IComponentManager componentManager)
            : base(componentManager)
        {
            Type = "text";
        }

        public override void Render(IHtmlWriter writer)
        {
            Attributes["value"] = Text;
            base.Render(writer);
        }

        public override void HandleValue(string value)
        {
            Text = value;
        }
    }
}

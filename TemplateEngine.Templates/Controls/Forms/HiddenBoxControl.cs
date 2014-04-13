using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class HiddenBoxControl : FormInputControlBase, ITextControl
    {
        public string Text { get; set; }

        public HiddenBoxControl(IComponentManager componentManager)
            : base(componentManager)
        {
            Type = "hidden";
        }

        public override void Render(IHtmlWriter writer)
        {
            Attributes["value"] = Text;
            base.Render(writer);
        }
    }
}

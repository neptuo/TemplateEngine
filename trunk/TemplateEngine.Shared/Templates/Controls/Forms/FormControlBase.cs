using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public abstract class FormControlBase : HtmlControlBase, IFormControl
    {
        public string Name { get; set; }

        public FormControlBase(IComponentManager componentManager)
            : base(componentManager, "input", true)
        { }

        public override void OnInit()
        {
            base.OnInit();

            if (ID == null)
                ID = Name;
        }

        public override void Render(IHtmlWriter writer)
        {
            Attributes["name"] = Name;
            base.Render(writer);
        }
    }
}

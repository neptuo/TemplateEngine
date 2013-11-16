using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public abstract class FormControlBase : ControlBase, IFormControl
    {
        public string Name { get; set; }

        public FormControlBase(IComponentManager componentManager)
            : base(componentManager)
        { }

        public override void Render(IHtmlWriter writer)
        {
            Attributes["name"] = Name;
            base.Render(writer);
        }

        public abstract void HandleValue(string value);
    }
}

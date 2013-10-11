using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    [Html("input")]
    public class CheckBoxControl : BaseControl, IFormControl
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }

        public CheckBoxControl(IComponentManager componentManager)
            : base(componentManager)
        {
            Attributes["type"] = "checkbox";
        }

        public override void Render(IHtmlWriter writer)
        {
            Attributes["name"] = Name;
            if (IsChecked)
                Attributes["checked"] = "checked";

            base.Render(writer);
        }

        public void HandleValue(string value)
        {
            IsChecked = value == "on";
        }
    }
}

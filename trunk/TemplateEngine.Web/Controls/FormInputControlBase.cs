using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    [Html("input", true)]
    public abstract class FormInputControlBase : FormControlBase
    {
        protected string Type { get; set; }

        public FormInputControlBase(IComponentManager componentManager)
            : base(componentManager)
        { }

        public override void Render(IHtmlWriter writer)
        {
            Attributes["type"] = Type;
            base.Render(writer);
        }
    }
}

using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class PartialViewControl : HtmlContentControlBase
    {
        public string Partial { get; set; }

        public PartialViewControl(IComponentManager componentManager)
            : base(componentManager, "div")
        { }

        public override void OnInit()
        {
            Guard.NotNull(Partial, "Partial");

            base.OnInit();
            Attributes.Add("data-update", Partial);
        }
    }
}

using Neptuo.TemplateEngine.Web.Controls.DesignData;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class OptionControl : HtmlContentControlBase
    {
        public bool IsSelected { get; set; }
        public object Value { get; set; }

        [Hint("Replace for Content property for setting via attribute.")]
        public string Text { get; set; }

        public OptionControl(IComponentManager componentManager)
            : base(componentManager, "option")
        { }

        public override void OnInit()
        {
            if (!String.IsNullOrEmpty(Text))
                Content = new List<object> { Text };

            base.OnInit();
        }

        protected override void RenderAttributes(IHtmlWriter writer)
        {
            if (Value != null)
            {
                if (IsSelected)
                    Attributes["selected"] = "selected";

                Attributes["value"] = ("" + Value);
            }

            base.RenderAttributes(writer);
        }
    }
}

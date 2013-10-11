using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Neptuo.Templates;

namespace Neptuo.TemplateEngine.Web.Controls
{
    [DefaultProperty("Text")]
    public class LiteralControl : BaseControl, ITextControl
    {
        public string Text { get; set; }

        public LiteralControl(IComponentManager componentManager)
            : base(componentManager)
        { }

        protected override void RenderBody(IHtmlWriter writer)
        {
            writer.Content(Text);
        }
    }
}

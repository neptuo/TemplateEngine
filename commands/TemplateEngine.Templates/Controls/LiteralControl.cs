using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Neptuo.Templates;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Control for renderin text.
    /// </summary>
    [DefaultProperty("Text")]
    public class LiteralControl : ControlBase, ITextControl
    {
        public string Text { get; set; }
        public string FormatString { get; set; }

        public LiteralControl(IComponentManager componentManager)
            : base(componentManager)
        { }

        public override void Render(IHtmlWriter writer)
        {
            if (!String.IsNullOrEmpty(FormatString))
                writer.Content(String.Format(FormatString, Text));
            else
                writer.Content(Text);
        }
    }
}

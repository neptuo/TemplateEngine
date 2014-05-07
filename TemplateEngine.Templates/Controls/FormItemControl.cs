using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class FormItemControl : ContentControlBase
    {
        private IGuidProvider guidProvider;

        public string LabelText { get; set; }
        public string HelpText { get; set; }

        public FormItemControl(IComponentManager componentManager, IGuidProvider guidProvider)
            : base(componentManager)
        {
            Guard.NotNull(guidProvider, "guidProvider");
            this.guidProvider = guidProvider;
        }

        public override void Render(IHtmlWriter writer)
        {
            writer
                .Tag("div")
                .Attribute("class", "form-group");

            //foreach (KeyValuePair<string, string> attribute in Attributes)
            //    writer.Attribute(attribute.Key, attribute.Value);

            if (!String.IsNullOrEmpty(LabelText))
            {
                writer
                    .Tag("label")
                    //.Attribute("class", "control-label")
                    .Attribute("for", GetForAttribute())
                    .Content(LabelText)
                    .CloseFullTag();
            }

            //writer
            //    .Tag("div")
            //    .Attribute("class", "controls");

            RenderBody(writer);

            if (!String.IsNullOrEmpty(HelpText))
            {
                writer
                    .Tag("p")
                    .Attribute("class", "help-block")
                    .Content(HelpText)
                    .CloseFullTag();
            }

            //writer
            //    .CloseFullTag();

            //if (!String.IsNullOrEmpty(LabelText))
            //{
            //    writer
            //        .CloseFullTag();
            //}

            writer
                .CloseFullTag();
        }

        protected string GetForAttribute()
        {
            if (Content.Any())
            {
                foreach (object control in Content)
                {
                    HtmlControlBase htmlControl = control as HtmlControlBase;
                    if (htmlControl != null)
                    {
                        if (!String.IsNullOrEmpty(htmlControl.ID))
                            return htmlControl.ID;

                        string id = guidProvider.Next();
                        htmlControl.ID = id;
                        return id;
                    }
                }
            }
            return null;
        }
    }
}

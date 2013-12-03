using Neptuo.Reflection;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public abstract class HtmlControlBase : ControlBase, IAttributeCollection
    {
        public string ID { get; set; }
        public string CssStyle { get; set; }
        public CssClassCollection CssClass { get; set; }

        protected virtual string TagName { get; set; }
        protected virtual bool IsSelfClosing { get; set; }

        public HtmlControlBase(IComponentManager componentManager, string tagName, bool isSelfClosing = false)
            : base(componentManager)
        {
            TagName = tagName;
            IsSelfClosing = isSelfClosing;
        }

        public override void Render(IHtmlWriter writer)
        {
            if (!String.IsNullOrEmpty(TagName))
            {
                writer.Tag(TagName);
                RenderAttributes(writer);

                if (IsSelfClosing)
                {
                    writer.CloseTag();
                }
                else
                {
                    RenderBody(writer);
                    writer.CloseFullTag();
                }
            }
            else
            {
                RenderBody(writer);
            }
        }

        protected virtual void RenderBody(IHtmlWriter writer) { }

        protected virtual void RenderAttributes(IHtmlWriter writer)
        {
            if (!String.IsNullOrEmpty(ID))
                Attributes["id"] = ID;

            if (CssClass != null)
            {
                if (!Attributes.ContainsKey("class"))
                    Attributes["class"] = String.Join(" ", CssClass);
                else
                    Attributes["class"] += " " + String.Join(" ", CssClass);
            }

            foreach (KeyValuePair<string, string> attribute in Attributes)
                writer.Attribute(attribute.Key, attribute.Value);
        }


        public void SetAttribute(string name, string value)
        {
            Attributes[name] = value;
        }
    }
}

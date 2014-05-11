using Neptuo.Reflection;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Base of html cotrol that can't has content.
    /// </summary>
    public abstract class HtmlControlBase : ControlBase, IAttributeCollection, IHtmlAttributeCollection
    {
        public string ID { get; set; }
        public string CssStyle { get; set; }
        public CssClassCollection CssClass { get; set; }

        public HtmlAttributeCollection Attributes { get; protected set; }

        /// <summary>
        /// Html tag name.
        /// </summary>
        protected virtual string TagName { get; set; }

        /// <summary>
        /// Is using self closing html tag.
        /// </summary>
        protected virtual bool IsSelfClosing { get; set; }

        public HtmlControlBase(IComponentManager componentManager, string tagName, bool isSelfClosing = false)
            : base(componentManager)
        {
            TagName = tagName;
            IsSelfClosing = isSelfClosing;
            Attributes = new HtmlAttributeCollection();
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
                    Attributes["class"] = String.Format("{0} {1}", Attributes["class"], String.Join(" ", CssClass));
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

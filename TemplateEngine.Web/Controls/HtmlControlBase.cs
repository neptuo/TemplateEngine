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
        private string tagName;
        private bool? isSelfClosing;

        protected virtual string TagName
        {
            get
            {
                if (tagName == null)
                {

                    HtmlAttribute attr = ReflectionHelper.GetAttribute<HtmlAttribute>(GetType());
                    if (attr != null)
                        tagName = attr.TagName;
                }
                return tagName;
            }
            set { tagName = value; }
        }

        protected virtual bool IsSelfClosing
        {
            get
            {
                if (isSelfClosing == null)
                {
                    HtmlAttribute attr = ReflectionHelper.GetAttribute<HtmlAttribute>(GetType());
                    if (attr != null)
                        isSelfClosing = attr.IsSelfClosing;

                }
                return isSelfClosing ?? true;
            }
            set { isSelfClosing = value; }
        }

        public HtmlControlBase(IComponentManager componentManager)
            : base(componentManager)
        { }

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
            foreach (KeyValuePair<string, string> attribute in Attributes)
                writer.Attribute(attribute.Key, attribute.Value);
        }


        public void SetAttribute(string name, string value)
        {
            Attributes[name] = value;
        }
    }
}

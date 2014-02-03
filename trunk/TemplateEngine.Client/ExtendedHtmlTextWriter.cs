using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class ExtendedHtmlTextWriter : HtmlTextWriter, IExtendedHtmlWriter
    {
        List<HtmlAttribute> pendingAttributes = new List<HtmlAttribute>();

        public ExtendedHtmlTextWriter(TextWriter writer)
            : base(writer)
        { }

        public IHtmlWriter AttributeOnNextTag(string name, string value)
        {
            pendingAttributes.Add(new HtmlAttribute(name, value));
            return this;
        }

        public override IHtmlWriter Tag(string name)
        {
            base.Tag(name);

            foreach (HtmlAttribute attribute in pendingAttributes)
                Attribute(attribute.Name, attribute.Value);

            pendingAttributes.Clear();
            return this;
        }

        public struct HtmlAttribute
        {
            public string Name;
            public string Value;

            public HtmlAttribute(string name, string value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}

using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    public class ExtendedHtmlTextWriter : HtmlTextWriter, IExtendedHtmlWriter
    {
        protected List<HtmlAttribute> PendingAttributes { get; private set; }

        public ExtendedHtmlTextWriter(TextWriter writer)
            : base(writer)
        {
            PendingAttributes = new List<HtmlAttribute>();
        }

        public IExtendedHtmlWriter AttributeOnNextTag(string name, string value)
        {
            PendingAttributes.Add(new HtmlAttribute(name, value));
            return this;
        }

        public override IHtmlWriter Tag(string name)
        {
            base.Tag(name);

            foreach (HtmlAttribute attribute in PendingAttributes)
                Attribute(attribute.Name, attribute.Value);

            PendingAttributes.Clear();
            return this;
        }

        protected struct HtmlAttribute
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

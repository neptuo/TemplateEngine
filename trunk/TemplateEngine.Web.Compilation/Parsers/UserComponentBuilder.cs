using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation.Parsers
{
    public class UserComponentBuilder : DefaultTypeComponentBuilder
    {
        public string TemplatePath { get; set; }

        public UserComponentBuilder(string templatePath)
            : base(typeof(TemplateControl))
        {
            if (templatePath == null)
                throw new ArgumentNullException("templatePath");

            TemplatePath = templatePath;
        }

        protected override void BindAttributes(IContentBuilderContext context, BindPropertiesContext bindContext, IComponentCodeObject codeObject, IEnumerable<IXmlAttribute> attributes)
        {
            base.BindAttributes(context, bindContext, codeObject, attributes);
        }
    }
}

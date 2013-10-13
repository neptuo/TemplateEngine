using Neptuo.Linq.Expressions;
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
    public class UserTemplateComponentBuilder : DefaultTypeComponentBuilder
    {
        public string TemplatePath { get; set; }

        public UserTemplateComponentBuilder(string templatePath)
            : base(typeof(TemplateControl))
        {
            if (templatePath == null)
                throw new ArgumentNullException("templatePath");

            TemplatePath = templatePath;
        }

        protected override void BindAttributes(IContentBuilderContext context, BindPropertiesContext bindContext, IComponentCodeObject codeObject, IEnumerable<IXmlAttribute> attributes)
        {
            IPropertyInfo propertyInfo = new TypePropertyInfo(
                typeof(TemplateControl).GetProperty(TypeHelper.PropertyName<TemplateControl, ITemplate>(t => t.Template))
            );
            if (context.BuilderRegistry.ContainsProperty(propertyInfo))
            {
                context.BuilderRegistry.GetPropertyBuilder(propertyInfo).Parse(context, codeObject, propertyInfo, TemplatePath);
            }
            else
            {
                codeObject.Properties.Add(
                    new SetPropertyDescriptor(
                        propertyInfo,
                        new PlainValueCodeObject(TemplatePath)
                    )
                );
            }
            base.BindAttributes(context, bindContext, codeObject, attributes);
        }
    }
}

using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Templates.Controls;
using Neptuo.Templates.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.Parsers
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

        protected override void AfterBindProperties(IContentBuilderContext context, BindPropertiesContext bindContext, IComponentCodeObject codeObject, IXmlElement element)
        {
            base.AfterBindProperties(context, bindContext, codeObject, element);

            if (element.Attributes.Any())
            {
                string contentPropertyName = TypeHelper.PropertyName<TemplateControl, object>(t => t.Content);
                IPropertyDescriptor propertyDescriptor = codeObject.Properties.Where(p => p.Property != null).FirstOrDefault(p => p.Property.Name == contentPropertyName);
                if (propertyDescriptor == null)
                {
                    propertyDescriptor = new ListAddPropertyDescriptor(new TypePropertyInfo(typeof(TemplateControl).GetProperty(contentPropertyName)));
                    codeObject.Properties.Add(propertyDescriptor);
                }

                foreach (IXmlAttribute attribute in element.Attributes)
                {
                    IComponentCodeObject contentCodeObject = new ComponentCodeObject(typeof(TemplateContentControl));
                    contentCodeObject.Properties.Add(
                        new SetPropertyDescriptor(
                            new TypePropertyInfo(
                                typeof(TemplateContentControl).GetProperty(TypeHelper.PropertyName<TemplateContentControl, string>(t => t.Name))
                            ),
                            new PlainValueCodeObject(attribute.Name)
                        )
                    );
                    contentCodeObject.Properties.Add(
                        new ListAddPropertyDescriptor(
                            new TypePropertyInfo(
                                typeof(TemplateContentControl).GetProperty(TypeHelper.PropertyName<TemplateContentControl, object>(t => t.Content))
                            ),
                            new PlainValueCodeObject(attribute.Value)
                        )
                    );
                    propertyDescriptor.SetValue(contentCodeObject);
                }
            }
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

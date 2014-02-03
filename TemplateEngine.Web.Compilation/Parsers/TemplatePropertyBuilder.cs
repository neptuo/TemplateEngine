using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Web.Compilation.CodeObjects;
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
    public class TemplatePropertyBuilder : IPropertyBuilder
    {
        public bool Parse(IContentBuilderContext context, IPropertiesCodeObject codeObject, IPropertyInfo propertyInfo, IEnumerable<IXmlNode> content)
        {
            // If content is only whitespace -> don't bind
            string contentText = String.Join("", content.Select(n => n.OuterXml));
            if (String.IsNullOrWhiteSpace(contentText))
                return true;

            //Collection item
            IPropertyDescriptor propertyDescriptor = TemplatePropertyHelper.PreparePropertyDescriptor(codeObject, propertyInfo);
            context.Parser.ProcessContent(context, propertyDescriptor, content);

            return true;
        }

        public bool Parse(IContentBuilderContext context, IPropertiesCodeObject codeObject, IPropertyInfo propertyInfo, string attributeValue)
        {
            IComponentCodeObject templateCodeObject = new ComponentCodeObject(typeof(FileTemplate));
            templateCodeObject.Properties.Add(
                new SetPropertyDescriptor(
                    new TypePropertyInfo(
                        typeof(FileTemplate).GetProperty(
                            TypeHelper.PropertyName<FileTemplate, string>(t => t.Path)
                        )
                    ),
                    new PlainValueCodeObject(attributeValue)
                )
            );

            IPropertyDescriptor propertyDescriptor = new SetPropertyDescriptor(propertyInfo);
            propertyDescriptor.SetValue(templateCodeObject);
            codeObject.Properties.Add(propertyDescriptor);

            return true;
        }
    }
}

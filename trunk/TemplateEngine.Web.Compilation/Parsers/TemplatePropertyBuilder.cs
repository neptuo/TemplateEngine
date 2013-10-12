﻿using Neptuo.Linq.Expressions;
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
            IComponentCodeObject templateCodeObject = new TemplateCodeObject(typeof(ContentTemplate));
            codeObject.Properties.Add(new SetPropertyDescriptor(propertyInfo, templateCodeObject));

            IPropertyInfo targetProperty = new TypePropertyInfo(
                templateCodeObject.GetType().GetProperty(
                    TypeHelper.PropertyName<ContentTemplateContent, object>(t => t.Content)
                )
            );

            //Collection item
            IPropertyDescriptor propertyDescriptor = new ListAddPropertyDescriptor(targetProperty);
            templateCodeObject.Properties.Add(propertyDescriptor);
            context.Parser.ProcessContent(context, propertyDescriptor, content);

            return true;
        }

        public bool Parse(IContentBuilderContext context, IPropertiesCodeObject codeObject, IPropertyInfo propertyInfo, string attributeValue)
        {
            IComponentCodeObject templateCodeObject = new ComponentCodeObject(typeof(FileTemplate));
            templateCodeObject.Properties.Add(
                new SetPropertyDescriptor(
                    new TypePropertyInfo(
                        templateCodeObject.GetType().GetProperty(
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

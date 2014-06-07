using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Templates.Compilation.CodeObjects;
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
    public static class TemplatePropertyHelper
    {
        public static IPropertyDescriptor PreparePropertyDescriptor(IPropertiesCodeObject codeObject, IPropertyInfo propertyInfo)
        {
            IComponentCodeObject templateCodeObject = new TemplateCodeObject(typeof(ContentTemplate));
            codeObject.Properties.Add(new SetPropertyDescriptor(propertyInfo, templateCodeObject));

            IPropertyInfo targetProperty = new TypePropertyInfo(
                typeof(ContentTemplateContent).GetProperty(
                    TypeHelper.PropertyName<ContentTemplateContent, object>(t => t.Content)
                )
            );

            //Collection item
            IPropertyDescriptor propertyDescriptor = new ListAddPropertyDescriptor(targetProperty);
            templateCodeObject.Properties.Add(propertyDescriptor);
            return propertyDescriptor;
        }
    }
}

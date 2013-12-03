using Neptuo.TemplateEngine.Web.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation.Parsers
{
    public class CssClassPropertyBuilder : IPropertyBuilder
    {
        public bool Parse(IContentBuilderContext context, IPropertiesCodeObject codeObject, IPropertyInfo propertyInfo, string attributeValue)
        {
            if(String.IsNullOrEmpty(attributeValue) || String.IsNullOrWhiteSpace(attributeValue))
                return true;

            CssClassPropertyDescriptor propertyDescriptor = new CssClassPropertyDescriptor(propertyInfo);
            string[] values = attributeValue.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string value in values)
                propertyDescriptor.SetValue(new PlainValueCodeObject(value));
            
            codeObject.Properties.Add(propertyDescriptor);
            return true;
        }

        public bool Parse(IContentBuilderContext context, IPropertiesCodeObject codeObject, IPropertyInfo propertyInfo, IEnumerable<IXmlNode> content)
        {
            throw new NotImplementedException();
        }
    }
}

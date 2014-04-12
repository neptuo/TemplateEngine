using Neptuo.TemplateEngine.Templates.Compilation.CodeObjects;
using Neptuo.TemplateEngine.Templates.Observers;
using Neptuo.Templates;
using Neptuo.Templates.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.Parsers
{
    public class LocalizationObserverBuilder : IObserverBuilder
    {
        public void Parse(IContentBuilderContext context, IComponentCodeObject codeObject, IEnumerable<IXmlAttribute> attributes)
        {
            ComponentCodeObject component = (ComponentCodeObject)codeObject;
            foreach (IXmlAttribute attribute in attributes)
            {
                PropertyInfo propertyInfo = component.Type.GetProperty(attribute.LocalName);
                if(propertyInfo == null)
                    continue;

                codeObject.Properties.Add(
                    new SetPropertyDescriptor(
                        new TypePropertyInfo(propertyInfo), 
                        new LocalizationCodeObject(attribute.Value)
                    )
                );
            }
        }
    }
}

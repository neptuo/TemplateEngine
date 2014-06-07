using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Templates.Compilation.CodeObjects;
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
    public class FormUriObserverBuider : IObserverBuilder
    {
        protected IFormUriRepository FormService { get; private set; }

        public FormUriObserverBuider(IFormUriRepository formService)
        {
            FormService = formService;
        }

        public void Parse(IContentBuilderContext context, IComponentCodeObject codeObject, IEnumerable<IXmlAttribute> attributes)
        {
            ComponentCodeObject component = (ComponentCodeObject)codeObject;
            foreach (IXmlAttribute attribute in attributes)
            {
                FormUri formUri;
                if (FormService.TryGet(attribute.Value, out formUri))
                {
                    IPropertyDescriptor propertyDescriptor = null;
                    PropertyInfo propertyInfo = component.Type.GetProperty(attribute.LocalName);
                    if (propertyInfo != null)
                    {
                        if (propertyInfo.PropertyType == typeof(string))
                            propertyDescriptor = new SetPropertyDescriptor(new TypePropertyInfo(propertyInfo), new ResolveUrlCodeObject(formUri.Url()));
                        else if (propertyInfo.PropertyType == typeof(FormUri))
                            propertyDescriptor = new SetPropertyDescriptor(new TypePropertyInfo(propertyInfo), new ExplicitCastCodeObject(typeof(FormUri), attribute.Value));
                        else
                            throw new InvalidOperationException(String.Format("Unnable to set property of type '{0}' with FormUri.", propertyInfo.PropertyType));

                        component.Properties.Add(propertyDescriptor);
                    }
                    else
                    {
                        BaseBuilder.BindAttributeCollection(context, component, component, attribute.LocalName, new ResolveUrlCodeObject(formUri.Url()));
                    }
                }
            }
        }
    }
}
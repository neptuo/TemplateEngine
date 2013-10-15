using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Web.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation.Parsers
{
    public class FormUriObserverBuider : IObserverBuilder
    {
        protected IFormUriService FormService { get; private set; }

        public FormUriObserverBuider(IFormUriService formService)
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
                        propertyDescriptor = new SetPropertyDescriptor(new TypePropertyInfo(propertyInfo), new ResolveUrlCodeObject(formUri.Url()));
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
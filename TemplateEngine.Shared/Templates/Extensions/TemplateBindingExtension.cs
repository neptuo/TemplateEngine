using Neptuo.TemplateEngine.Templates.Controls;
using Neptuo.Templates;
using Neptuo.Templates.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Extensions
{
    public class TemplateBindingExtension : BindingExtension
    {
        public TemplateBindingExtension(DataContextStorage dataContext, IBindingManager bindingManager, IValueConverterService converterService)
            : base(dataContext, bindingManager, converterService)
        { }

        protected override object GetData()
        {
            object source = DataContext.Peek("Template");
            object value;
            if (BindingManager.TryGetValue(Expression, source, out value))
                return value;

            IHtmlAttributeCollection attributeSource = source as IHtmlAttributeCollection;
            if(attributeSource != null)
            {
                string attributeValue;
                if (attributeSource.Attributes.TryGetValue(Expression.ToLowerInvariant(), out attributeValue))
                    return attributeValue;
            }

            return null;
        }
    }
}

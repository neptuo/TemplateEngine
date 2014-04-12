using Neptuo.Templates.Compilation.CodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.CodeObjects
{
    public class CssClassPropertyDescriptor : ListAddPropertyDescriptor
    {
        public CssClassPropertyDescriptor(IPropertyInfo propertyName)
            : base(propertyName)
        { }

        public CssClassPropertyDescriptor(IPropertyInfo propertyName, params ICodeObject[] values) 
            : base(propertyName, values)
        { }
    }
}

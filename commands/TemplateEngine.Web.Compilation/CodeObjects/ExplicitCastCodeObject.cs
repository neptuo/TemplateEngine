using Neptuo.Templates.Compilation.CodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.CodeObjects
{
    public class ExplicitCastCodeObject : ICodeObject, ITypeCodeObject
    {
        public Type Type { get; set; }
        public object Value { get; set; }

        public ExplicitCastCodeObject(Type type, object value)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            if (value == null)
                throw new ArgumentNullException("value");

            Type = type;
            Value = value;
        }
    }
}

using Neptuo.Templates.Compilation.CodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation.CodeObjects
{
    public class TemplateCodeObject : ComponentCodeObject
    {
        public TemplateCodeObject(Type type)
            : base(type)
        { }
    }

}

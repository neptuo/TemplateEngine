using Neptuo.Templates.Compilation.CodeObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.CodeObjects
{
    public class MethodReferenceCodeObject : ICodeObject
    {
        public string MethodName { get; set; }

        public MethodReferenceCodeObject(string methodName)
        {
            MethodName = methodName;
        }
    }
}

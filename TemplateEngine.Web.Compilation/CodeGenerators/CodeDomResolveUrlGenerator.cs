using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Templates.Compilation.CodeObjects;
using Neptuo.TemplateEngine.Web;
using Neptuo.Templates.Compilation.CodeGenerators;
using Neptuo.Templates.Compilation.CodeObjects;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.CodeGenerators
{
    public class CodeDomResolveUrlGenerator : BaseCodeDomObjectGenerator<ResolveUrlCodeObject>
    {
        protected override CodeExpression GenerateCode(CodeObjectExtensionContext context, ResolveUrlCodeObject codeObject, IPropertyDescriptor propertyDescriptor)
        {
            return new CodeMethodInvokeExpression(
                new CodeThisReferenceExpression(),
                TypeHelper.MethodName<GeneratedViewBase, string, string>(v => v.ResolveUrl),
                new CodePrimitiveExpression(codeObject.RelativeUrl)
            );
        }
    }
}

using Neptuo.TemplateEngine.Templates.Compilation.CodeObjects;
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
    public class CodeDomExplicitCastGenerator : BaseCodeDomObjectGenerator<ExplicitCastCodeObject>
    {
        protected override CodeExpression GenerateCode(CodeObjectExtensionContext context, ExplicitCastCodeObject codeObject, IPropertyDescriptor propertyDescriptor)
        {
            return new CodeCastExpression(
                new CodeTypeReference(codeObject.Type),
                new CodePrimitiveExpression(codeObject.Value)
            );
        }
    }
}

using Neptuo.Linq.Expressions;
using Neptuo.Templates.Compilation.CodeGenerators;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation.CodeGenerators
{
    public class CodeDomPropertySetAttributeGenerator : BaseCodeDomAttributeGenerator<PropertySetAttribute>
    {
        protected override CodeExpression GenerateCode(CodeDomAttributeContext context, PropertySetAttribute attribute)
        {
            return new CodeMethodInvokeExpression(
                new CodeMethodReferenceExpression(
                    new CodeThisReferenceExpression(),
                    "ValueFromRequest",
                    new CodeTypeReference(context.PropertyInfo.PropertyType)
                ),
                new CodePrimitiveExpression(attribute.RequestKey ?? context.PropertyInfo.Name)
            );
        }
    }
}

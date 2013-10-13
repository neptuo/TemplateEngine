using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Web.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.CodeGenerators;
using Neptuo.Templates.Compilation.CodeObjects;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation.CodeGenerators
{
    public class CodeDomLocalizationGenerator : BaseCodeDomObjectGenerator<LocalizationCodeObject>
    {
        protected override CodeExpression GenerateCode(CodeObjectExtensionContext context, LocalizationCodeObject codeObject, IPropertyDescriptor propertyDescriptor)
        {
            return new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression(typeof(LocalizationHelper)),
                "Translate",
                new CodePrimitiveExpression(codeObject.Text)
            );
        }
    }
}

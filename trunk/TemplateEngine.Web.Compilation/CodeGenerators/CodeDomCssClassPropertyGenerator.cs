using Neptuo.Linq.Expressions;
using Neptuo.TemplateEngine.Web.Compilation.CodeObjects;
using Neptuo.TemplateEngine.Web.Controls;
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
    public class CodeDomCssClassPropertyGenerator : BaseCodeDomPropertyGenerator<CssClassPropertyDescriptor>
    {
        private static readonly string addMethodName = TypeHelper.MethodName<CssClassCollection, string>(c => c.Add);

        protected override void GenerateProperty(CodeDomPropertyContext context, CssClassPropertyDescriptor propertyDescriptor)
        {
            CodeExpression targetField = GetPropertyTarget(context);
            CodeExpression codePropertyReference = new CodePropertyReferenceExpression(
                targetField,
                propertyDescriptor.Property.Name
            );

            context.Statements.Add(
                new CodeAssignStatement(
                    codePropertyReference,
                    new CodeObjectCreateExpression(typeof(CssClassCollection))
                )
            );

            foreach (ICodeObject propertyValue in propertyDescriptor.Values)
            {
                CodeExpression codeExpression = context.CodeGenerator.GenerateCodeObject(
                    new CodeObjectExtensionContext(context.Context, context.FieldName),
                    propertyValue,
                    propertyDescriptor
                );
                context.Statements.Add(
                    new CodeMethodInvokeExpression(
                        codePropertyReference,
                        addMethodName,
                        codeExpression
                    )
                );
            }
        }
    }
}

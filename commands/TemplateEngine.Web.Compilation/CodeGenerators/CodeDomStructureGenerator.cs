using Neptuo.TemplateEngine.Templates;
using Neptuo.TemplateEngine.Web;
using Neptuo.Templates.Compilation.CodeGenerators;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation.CodeGenerators
{
    public class CodeDomStructureGenerator : Neptuo.Templates.Compilation.CodeGenerators.CodeDomStructureGenerator
    {
        protected override void CreateCodeClass(BaseCodeDomStructure structure, CodeDomStructureContext context)
        {
            string sourceName = null;
            if (context.Naming.SourceName != null)
                sourceName = context.Naming.SourceName.Replace("\\", "/");

            base.CreateCodeClass(structure, context);

            structure.Class.CustomAttributes.Add(
                new CodeAttributeDeclaration(
                    new CodeTypeReference(typeof(ViewAttribute)), 
                    new CodeAttributeArgument(new CodePrimitiveExpression(sourceName))
                )
            );
        }

        protected override void SetBaseTypes(CodeTypeDeclaration typeDeclaration)
        {
            typeDeclaration.BaseTypes.Add(new CodeTypeReference(typeof(GeneratedViewBase)));
            typeDeclaration.BaseTypes.Add(new CodeTypeReference(typeof(IDisposable)));
        }
    }
}

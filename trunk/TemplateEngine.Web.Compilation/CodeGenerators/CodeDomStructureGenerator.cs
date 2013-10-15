using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation.CodeGenerators
{
    public class CodeDomStructureGenerator : Neptuo.Templates.Compilation.CodeGenerators.CodeDomStructureGenerator
    {
        protected override void SetBaseTypes(CodeTypeDeclaration typeDeclaration)
        {
            typeDeclaration.BaseTypes.Add(new CodeTypeReference(typeof(GeneratedViewBase)));
            typeDeclaration.BaseTypes.Add(new CodeTypeReference(typeof(IDisposable)));
        }
    }
}

using Neptuo.SharpKit.CodeGenerator;
using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation
{
    public class ExtendedViewService : CodeDomViewService, IJavascriptSourceViewService
    {
        public string GenerateSourceCode(string viewContent, IViewServiceContext context, INaming naming)
        {
            string sourceCode = GenerateSourceCodeFromView(viewContent, context, naming);
            return sourceCode;
        }

        public void CompileViewContent(string viewContent, IViewServiceContext context, INaming naming)
        {
            base.CompileView(viewContent, context, naming);
        }

        public string GenerateJavascript(string viewContent, IViewServiceContext context, INaming naming, string optionalViewPath)
        {
            string sourceCode = GenerateSourceCode(viewContent, context, naming);
            string replaceClassDefinition = String.Format(
                "[SharpKit.JavaScript.JsType(SharpKit.JavaScript.JsMode.Clr)] {0} public sealed class ", 
                GetViewAttributeSourceCode(optionalViewPath)
            );

            sourceCode = sourceCode.Replace("public sealed class ", replaceClassDefinition);

            StringWriter output = new StringWriter();
            StringReader input = new StringReader(sourceCode);

            SharpKitCompiler sharpKitGenerator = new SharpKitCompiler();
            sharpKitGenerator.AddReference("mscorlib.dll");
            sharpKitGenerator.AddReference("SharpKit.JavaScript.dll", "SharpKit.Html.dll", "SharpKit.jQuery.dll");
            sharpKitGenerator.AddPlugin("Neptuo.SharpKit.Exugin", "Neptuo.SharpKit.Exugin.ExuginPlugin");

            foreach (string folder in BinDirectories)
                sharpKitGenerator.AddReferenceFolder(folder);

            sharpKitGenerator.RemoveReference("System.Web.dll");

            sharpKitGenerator.TempDirectory = TempDirectory;
            sharpKitGenerator.Generate(new SharpKitCompilerContext(input, output));
            return output.ToString();
        }

        private string GetViewAttributeSourceCode(string optionalViewPath)
        {
            if (String.IsNullOrEmpty(optionalViewPath))
                return String.Empty;

            return String.Format("[Neptuo.TemplateEngine.Web.View(\"{0}\")]", optionalViewPath);
        }
    }
}

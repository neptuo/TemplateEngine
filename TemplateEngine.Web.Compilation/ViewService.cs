using Neptuo.SharpKit.CodeGenerator;
using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using Neptuo.Templates.Compilation.CodeGenerators;
using Neptuo.Templates.Compilation.CodeObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation
{
    public class ViewService : CodeDomViewService
    {
        public string GenerateJavascriptSourceCodeFromView(string viewContent, IViewServiceContext context, INaming naming)
        {
            IPropertyDescriptor propertyDescriptor = ParseViewContent(viewContent, context);
            return GenerateJavascriptSourceCode(propertyDescriptor, context, naming);
        }
    }
}

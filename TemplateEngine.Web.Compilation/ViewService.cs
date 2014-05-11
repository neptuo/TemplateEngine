using Neptuo.SharpKit.CodeGenerator;
using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using Neptuo.Templates.Compilation.CodeGenerators;
using Neptuo.Templates.Compilation.CodeObjects;
using Neptuo.Templates.Compilation.PreProcessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Compilation
{
    /// <summary>
    /// TemplateEngine view service.
    /// </summary>
    public class ViewService : CodeDomViewService
    {
        public ViewService()
            : base(true)
        { }

        /// <summary>
        /// Gets generated javascript code for <paramref name="viewContent"/>.
        /// </summary>
        public string GenerateJavascriptSourceCodeFromView(string viewContent, IViewServiceContext context, INaming naming)
        {
            IPropertyDescriptor propertyDescriptor = ParseViewContent(viewContent, context);
            PreProcessorService.Process(propertyDescriptor, new DefaultPreProcessorServiceContext(context.DependencyProvider));

            return GenerateJavascriptSourceCode(propertyDescriptor, context, naming);
        }
    }
}

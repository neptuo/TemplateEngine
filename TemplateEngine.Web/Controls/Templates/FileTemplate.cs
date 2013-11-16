using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class FileTemplate : ViewTemplateBase
    {
        public string Path { get; set; }

        public FileTemplate(IDependencyProvider dependencyProvider, IComponentManager componentManager, IViewService viewService)
            : base(dependencyProvider, componentManager, viewService)
        { }

        protected override BaseGeneratedView CreateView()
        {
            return (BaseGeneratedView)ViewService.Process(Path, new ViewServiceContext(DependencyProvider));
        }
    }
}

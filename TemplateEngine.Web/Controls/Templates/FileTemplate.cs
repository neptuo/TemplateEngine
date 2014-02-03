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
        protected IViewActivator ViewActivator { get; private set; }
        public string Path { get; set; }

        public FileTemplate(IDependencyProvider dependencyProvider, IComponentManager componentManager, IViewActivator viewActivator)
            : base(dependencyProvider, componentManager)
        {
            ViewActivator = viewActivator;
        }

        protected override BaseGeneratedView CreateView()
        {
            return ViewActivator.CreateView(Path);
        }
    }
}

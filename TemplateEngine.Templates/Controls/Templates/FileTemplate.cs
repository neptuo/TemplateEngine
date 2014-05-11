using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Implementation of <see cref="ITemplate"/> that is stored in separte file.
    /// </summary>
    public class FileTemplate : ViewTemplateBase
    {
        protected IViewActivator ViewActivator { get; private set; }
        public string Path { get; set; }

        public FileTemplate(IDependencyProvider dependencyProvider, IComponentManager componentManager, IViewActivator viewActivator)
            : base(dependencyProvider, componentManager)
        {
            ViewActivator = viewActivator;
        }

        /// <summary>
        /// Create instance of template using <see cref="IViewActivator"/>.
        /// </summary>
        /// <returns></returns>
        protected override BaseGeneratedView CreateView()
        {
            return ViewActivator.CreateView(Path);
        }
    }
}

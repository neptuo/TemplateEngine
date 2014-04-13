using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    public class ViewServiceViewActivator : IViewActivator
    {
        private IDependencyProvider dependencyProvider;
        private IViewService viewService;

        public ViewServiceViewActivator(IDependencyProvider dependencyProvider, IViewService viewService)
        {
            this.dependencyProvider = dependencyProvider;
            this.viewService = viewService;
        }

        public BaseGeneratedView CreateView(string path)
        {
            return (BaseGeneratedView)viewService.Process(path, new ViewServiceContext(dependencyProvider));
        }
    }
}

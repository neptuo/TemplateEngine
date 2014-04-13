using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    [Obsolete]
    public class StringTemplate : ViewTemplateBase
    {
        protected IViewService ViewService { get; private set; }
        public string TemplateContent { get; set; }

        public StringTemplate(IDependencyProvider dependencyProvider, IComponentManager componentManager, IViewService viewService)
            : base(dependencyProvider, componentManager)
        {
            ViewService = viewService;
        }

        protected override BaseGeneratedView CreateView()
        {
            return (BaseGeneratedView)ViewService.ProcessContent(TemplateContent, new ViewServiceContext(DependencyProvider));
        }
    }
}

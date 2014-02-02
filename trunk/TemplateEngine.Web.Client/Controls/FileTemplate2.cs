using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class FileTemplate2 : ITemplate
    {
        private IDependencyProvider dependencyProvider;
        private IComponentManager componentManager;

        public string Path { get; set; }

        public FileTemplate2(IDependencyProvider dependencyProvider, IComponentManager componentManager)
        {
            this.dependencyProvider = dependencyProvider;
            this.componentManager = componentManager;
        }

        protected BaseGeneratedView CreateView()
        {
            throw new NotSupportedException();
        }

        public ITemplateContent CreateInstance()
        {
            BaseGeneratedView view = CreateView();
            view.Setup(new BaseViewPage(componentManager), componentManager, dependencyProvider);
            view.CreateControls();

            ViewTemplateContent templateContent = new ViewTemplateContent(view);
            componentManager.AddComponent(templateContent, null);
            return templateContent;
        }

        public void Dispose()
        { }
    }
}

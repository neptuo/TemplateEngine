using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public abstract class ViewTemplateBase : ITemplate
    {
        protected IDependencyProvider DependencyProvider { get; private set; }
        protected IComponentManager ComponentManager { get; private set; }

        public ViewTemplateBase(IDependencyProvider dependencyProvider, IComponentManager componentManager)
        {
            DependencyProvider = dependencyProvider;
            ComponentManager = componentManager;
        }

        public ITemplateContent CreateInstance()
        {
            BaseGeneratedView view = CreateView();
            view.Setup(new BaseViewPage(ComponentManager), ComponentManager, DependencyProvider);
            view.CreateControls();

            ViewTemplateContent templateContent = new ViewTemplateContent(view);
            ComponentManager.AddComponent(templateContent, null);
            return templateContent;
        }

        protected abstract BaseGeneratedView CreateView();

        public void Dispose()
        { }
    }
}

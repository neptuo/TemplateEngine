using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Base implementation of <see cref="ITemplate"/> operating on separated compiled template.
    /// </summary>
    public abstract class ViewTemplateBase : ITemplate
    {
        protected IDependencyProvider DependencyProvider { get; private set; }
        protected IComponentManager ComponentManager { get; private set; }

        public ViewTemplateBase(IDependencyProvider dependencyProvider, IComponentManager componentManager)
        {
            DependencyProvider = dependencyProvider;
            ComponentManager = componentManager;
        }

        /// <summary>
        /// Creates instance of <see cref="ITemplateContent"/>.
        /// </summary>
        public ITemplateContent CreateInstance()
        {
            BaseGeneratedView view = CreateView();
            view.Setup(new BaseViewPage(ComponentManager), ComponentManager, DependencyProvider);
            view.CreateControls();

            ViewTemplateContent templateContent = new ViewTemplateContent(view);
            ComponentManager.AddComponent(templateContent, null);
            return templateContent;
        }

        /// <summary>
        /// Override to create instance of current view.
        /// </summary>
        protected abstract BaseGeneratedView CreateView();

        public void Dispose()
        { }
    }
}

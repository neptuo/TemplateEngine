using Neptuo.TemplateEngine.Templates.Controls;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Implementation of <see cref="ITemplate"/> that is set inside of template using inner element.
    /// </summary>
    public class ContentTemplate : ITemplate
    {
        /// <summary>
        /// Current component manager.
        /// </summary>
        protected IComponentManager ComponentManager { get; private set; }

        /// <summary>
        /// Bind method that setups content of element.
        /// </summary>
        public Action<ContentTemplateContent> BindMethod { get; set; }

        public ContentTemplate(IComponentManager componentManager)
        {
            ComponentManager = componentManager;
        }

        /// <summary>
        /// Creates instance of template using <see cref="BindMethod"/> as source of values in templates.
        /// </summary>
        public ITemplateContent CreateInstance()
        {
            ContentTemplateContent templateContent = new ContentTemplateContent(ComponentManager);
            ComponentManager.AddComponent(templateContent, BindMethod);
            return templateContent;
        }

        public void Dispose()
        { }
    }
}

using Neptuo.TemplateEngine.Templates.Controls;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class ContentTemplate : ITemplate
    {
        protected IComponentManager ComponentManager { get; private set; }
        public Action<ContentTemplateContent> BindMethod { get; set; }

        public ContentTemplate(IComponentManager componentManager)
        {
            ComponentManager = componentManager;
        }

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

using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    [DefaultProperty("Content")]
    public class TemplateControl : ControlBase
    {
        public ICollection<TemplateContentControl> Content { get; set; }
        public ITemplate Template { get; set; }
        protected ITemplateContent TemplateContent { get; set; }
        protected TemplateContentStorageStack TemplateStorageStack { get; private set; }
        protected TemplateContentStorage TemplateStorage { get; private set; }

        public TemplateControl(IComponentManager componentManager, TemplateContentStorageStack contents)
            : base(componentManager)
        {
            TemplateStorageStack = contents;
            TemplateStorage = contents.CreateStorage();
        }

        public override void OnInit()
        {
            InitComponents(Content);

            if (Content != null)
                TemplateStorage.AddRange(Content);

            TemplateStorageStack.Push(TemplateStorage);

            base.OnInit();

            InitComponent(Template);
            TemplateContent = Template.CreateInstance();
            InitComponent(TemplateContent);

            TemplateStorageStack.Pop();
        }

        public override void Render(IHtmlWriter writer)
        {
            TemplateStorageStack.Push(TemplateStorage);
            RenderComponent(TemplateContent, writer);
            TemplateStorageStack.Pop();
        }

        protected TemplateControl InitTemplate(ITemplate template)
        {
            TemplateControl control = new TemplateControl(ComponentManager, TemplateStorageStack);
            control.Template = template;
            ComponentManager.AddComponent(control, null);
            InitComponent(control);
            return control;
        }
    }
}

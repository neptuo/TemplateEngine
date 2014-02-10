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
        protected TemplateContentStorageStack Contents { get; private set; }
        protected ITemplateContent TemplateContent { get; set; }
        protected TemplateContentStorage Storage { get; private set; }

        public TemplateControl(IComponentManager componentManager, TemplateContentStorageStack contents)
            : base(componentManager)
        {
            Contents = contents;
            Storage = contents.CreateStorage();
        }

        public override void OnInit()
        {
            InitComponents(Content);

            if (Content != null)
                Storage.AddRange(Content);

            Contents.Push(Storage);

            base.OnInit();

            InitComponent(Template);
            TemplateContent = Template.CreateInstance();
            InitComponent(TemplateContent);

            Contents.Pop();
        }

        public override void Render(IHtmlWriter writer)
        {
            Contents.Push(Storage);
            RenderComponent(TemplateContent, writer);
            Contents.Pop();
        }

        protected TemplateControl InitTemplate(ITemplate template)
        {
            TemplateControl control = new TemplateControl(ComponentManager, Contents);
            control.Template = template;
            ComponentManager.AddComponent(control, null);
            InitComponent(control);
            return control;
        }
    }
}

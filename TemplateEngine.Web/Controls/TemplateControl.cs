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
        protected IStackStorage<TemplateContentStorage> Contents { get; private set; }
        protected ITemplateContent TemplateContent { get; set; }
        protected TemplateContentStorage Storage { get; private set; }

        public TemplateControl(IComponentManager componentManager, IStackStorage<TemplateContentStorage> contents)
            : base(componentManager)
        {
            Contents = contents;
            Storage = new TemplateContentStorage();
        }

        public override void OnInit()
        {
            Init(Content);

            if (Content != null)
                Storage.AddRange(Content);

            Contents.Push(Storage);

            base.OnInit();

            Init(Template);
            TemplateContent = Template.CreateInstance();
            Init(TemplateContent);

            Contents.Pop();
        }

        protected override void RenderBody(IHtmlWriter writer)
        {
            Contents.Push(Storage);
            Render(TemplateContent, writer);
            Contents.Pop();
        }
    }
}

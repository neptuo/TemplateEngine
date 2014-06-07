using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Template control that enables template composition.
    /// </summary>
    [DefaultProperty("Content")]
    public class TemplateControl : ControlBase
    {
        /// <summary>
        /// List of contens for placeholders.
        /// </summary>
        public ICollection<TemplateContentControl> Content { get; set; }

        /// <summary>
        /// Current templates.
        /// </summary>
        public ITemplate Template { get; set; }

        /// <summary>
        /// Instance of <see cref="Template"/>.
        /// </summary>
        protected ITemplateContent TemplateContent { get; set; }

        /// <summary>
        /// Storage for contents.
        /// </summary>
        protected TemplateContentStorageStack TemplateStorageStack { get; private set; }

        /// <summary>
        /// Storage for contents.
        /// </summary>
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

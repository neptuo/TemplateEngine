using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    [DefaultProperty("Content")]
    public abstract class ContentControlBase : ControlBase, IContentControl
    {
        public ICollection<object> Content { get; set; }
        
        public ContentControlBase(IComponentManager componentManager)
            : base(componentManager)
        { }

        public override void OnInit()
        {
            base.OnInit();

            if (Content != null)
            {
                foreach (object item in Content)
                    ComponentManager.Init(item);
            }
        }

        public override void Render(IHtmlWriter writer)
        {
            RenderBody(writer);
        }

        protected virtual void RenderBody(IHtmlWriter writer)
        {
            if (Content != null)
            {
                foreach (object item in Content)
                    ComponentManager.Render(item, writer);
            }
        }
    }
}

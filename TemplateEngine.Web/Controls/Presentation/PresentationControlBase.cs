using Neptuo.PresentationModels;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public abstract class PresentationControlBase : TemplateControl
    {
        protected DataContextStorage DataContext { get; private set; }
        protected IModelValueGetter ModelGetter { get; private set; }

        public PresentationControlBase(IComponentManager componentManager, PresentationConfiguration configuration)
            : base(componentManager, configuration.TemplateStorage)
        {
            DataContext = configuration.DataContext;
        }

        protected abstract IModelValueGetter CreateModel();

        public override void OnInit()
        {
            Init(Template);
            TemplateContent = Template.CreateInstance();

            ModelGetter = CreateModel();
            DataContext.Push(ModelGetter);
            base.OnInit();
            DataContext.Pop();
        }

        public override void Render(IHtmlWriter writer)
        {
            DataContext.Push(ModelGetter);
            base.Render(writer);
            DataContext.Pop();
        }
    }
}

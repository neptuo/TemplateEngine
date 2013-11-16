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
    public class PresentationControlBase : TemplateControl
    {
        public IModelDefinition ModelDefinition { get; private set; }

        protected IModelPresenter ModelPresenter { get; private set; }
        protected TemplateModelView ModelView { get; private set; }

        public PresentationControlBase(IComponentManager componentManager, PresentationConfiguration configuration)
            : base(componentManager, configuration.TemplateStorage)
        {
            ModelView = new TemplateModelView(ComponentManager, configuration.ViewStorage);
            ModelDefinition = new FilteredModelDefinition(configuration.ModelDefinition, ModelView);
            ModelPresenter = new DefaultModelPresenter(ModelDefinition, ModelView);
        }

        public override void OnInit()
        {
            Init(Template);
            TemplateContent = Template.CreateInstance();
            //Init(TemplateContent);
            ModelView.Template = TemplateContent;
            ModelView.OnInit(base.OnInit);
        }

        public void SetData(IModelValueGetter getter)
        {
            ModelPresenter.SetData(getter);
        }

        public void GetData(IModelValueSetter setter)
        {
            ModelPresenter.GetData(setter);
        }
    }
}

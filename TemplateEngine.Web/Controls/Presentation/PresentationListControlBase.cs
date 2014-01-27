using Neptuo.PresentationModels;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public abstract class PresentationListControlBase<T> : TemplateControl
    {
        private PresentationConfiguration configuration;

        public ITemplate ItemTemplate { get; set; }
        protected DataContextStorage DataContext { get; private set; }

        public PresentationListControlBase(IComponentManager componentManager, PresentationConfiguration configuration)
            : base(componentManager, configuration.TemplateStorage)
        {
            this.configuration = configuration;
            DataContext = configuration.DataContext;
        }

        protected abstract IEnumerable<T> LoadData();

        public override void OnInit()
        {
            InitComponent(ItemTemplate);

            List<object> itemTemplates = new List<object>();
            IEnumerable<T> models = LoadData();
            foreach (T model in models)
            {
                IModelValueProvider provider = configuration.ValueProviderFactory.Create(model);
                DataContext.Push(provider);

                TemplateControl control = new TemplateControl(ComponentManager, configuration.TemplateStorage);
                control.Template = ItemTemplate;
                ComponentManager.AddComponent(control, null);
                InitComponent(control);
                itemTemplates.Add(control);

                DataContext.Pop();
            }

            TemplateContentControl templateContent = new TemplateContentControl(ComponentManager)
            {
                Name = "Content",
                Content = itemTemplates
            };
            ComponentManager.AddComponent(templateContent, null);
            InitComponent(templateContent);
            Content.Add(templateContent);

            base.OnInit();
        }
    }
}

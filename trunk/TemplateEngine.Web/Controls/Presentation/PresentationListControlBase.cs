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
        protected List<T> Models { get; private set; }
        protected DataContextStorage DataContext { get; private set; }
        //protected List<PresentationControlBase> ItemTemplates { get; private set; }

        public PresentationListControlBase(IComponentManager componentManager, TemplateContentStorageStack viewStorage, PresentationConfiguration configuration)
            : base(componentManager, viewStorage)
        {
            this.configuration = configuration;
            Models = new List<T>();
            DataContext = configuration.DataContext;
            //ItemTemplates = new List<PresentationControlBase>();
        }

        public override void OnInit()
        {
            Init(ItemTemplate);

            List<object> itemTemplates = new List<object>();
            foreach (T model in Models)
            {
                IModelValueProvider provider = configuration.ValueProviderFactory.Create(model);
                DataContext.Push(provider);

                //PresentationControlBase control = new PresentationControlBase(ComponentManager, configuration);
                TemplateControl control = new TemplateControl(ComponentManager, configuration.TemplateStorage);
                control.Template = ItemTemplate;
                ComponentManager.AddComponent(control, null);
                Init(control);
                itemTemplates.Add(control);
                //control.SetData(provider);

                DataContext.Pop();
            }

            TemplateContentControl templateContent = new TemplateContentControl(ComponentManager)
            {
                Name = "Content",
                Content = itemTemplates
            };
            ComponentManager.AddComponent(templateContent, null);
            Init(templateContent);
            Content.Add(templateContent);

            base.OnInit();
        }

        //public override void Render(IHtmlWriter writer)
        //{
        //    foreach (PresentationControlBase control in ItemTemplates)
        //        Render(control, writer);
        //}
    }
}

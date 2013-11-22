using Neptuo.Templates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class ListViewControl : TemplateControl
    {
        public IDataSource Source { get; set; }
        public ITemplate ItemTemplate { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        protected DataContextStorage DataContext { get; private set; }
        protected int TotalCount { get; private set; }

        public ListViewControl(IComponentManager componentManager, TemplateContentStorageStack storage, DataContextStorage dataContext)
            : base(componentManager, storage)
        {
            DataContext = dataContext;
        }

        public override void OnInit()
        {
            Init(ItemTemplate);
            Init(Source);

            if (Source == null)
                throw new InvalidOperationException("Missing data source.");

            List<object> itemTemplates = new List<object>();

            IEnumerable models = Source.GetData(PageIndex, PageSize);
            TotalCount = Source.GetTotalCount();
            foreach (object model in models)
            {
                DataContext.Push(model);

                TemplateControl control = new TemplateControl(ComponentManager, Contents);
                control.Template = ItemTemplate;
                ComponentManager.AddComponent(control, null);
                Init(control);
                itemTemplates.Add(control);

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

        protected override void RenderBody(IHtmlWriter writer)
        {
            base.RenderBody(writer);

            if (PageSize != null)
            {
                writer
                    .Tag("ul")
                    .Attribute("class", "pagination pagination-sm");

                for (int i = 0; i < (TotalCount / PageSize); i++)
                {
                    writer
                        .Tag("li")
                        .Attribute("class", ((PageIndex ?? 0) == i) ? "active" : "")
                            .Tag("a")
                            .Attribute("href", (i != 0) ? ("?PageIndex=" + i) : "?")
                            .Content(i + 1)
                            .CloseFullTag()
                        .CloseFullTag();
                }

                writer
                    .CloseFullTag();
            }
        }
    }
}

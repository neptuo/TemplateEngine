﻿using Neptuo.Templates;
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
        public IListDataSource Source { get; set; }
        public ITemplate ItemTemplate { get; set; }
        public ITemplate EmptyTemplate { get; set; }
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
            InitComponent(ItemTemplate);
            if (ItemTemplate == null)
                throw new ArgumentException("Missing item template.", "ItemTemplate");

            InitComponent(Source);
            if (Source == null)
                throw new ArgumentException("Missing data source.", "Source");

            List<object> itemTemplates = new List<object>();

            IEnumerable models = GetModelPage(PageIndex, PageSize);
            TotalCount = Source.GetTotalCount();
            DataContext.Push(this, "Template");

            bool isEmpty = true;
            foreach (object model in models)
            {
                isEmpty = false;
                ProcessModelItem(itemTemplates, model);
            }

            if (isEmpty && EmptyTemplate != null)
            {
                Template = EmptyTemplate;
            }
            else
            {
                TemplateContentControl templateContent = new TemplateContentControl(ComponentManager)
                {
                    Name = "Content",
                    Content = itemTemplates
                };
                ComponentManager.AddComponent(templateContent, null);
                InitComponent(templateContent);
                Content.Add(templateContent);
            }

            base.OnInit();
            DataContext.Pop("Template");
        }

        protected virtual IEnumerable GetModelPage(int? pageIndex, int? pageSize)
        {
            return Source.GetData(pageIndex, pageSize);
        }

        protected virtual void ProcessModelItem(List<object> itemTemplates, object model)
        {
            DataContext.Push(model);
            itemTemplates.Add(InitTemplate(ItemTemplate));
            DataContext.Pop();
        }

        public override void Render(IHtmlWriter writer)
        {
            base.Render(writer);

            if (PageSize != null)
            {
                writer
                    .Tag("ul")
                    .Attribute("class", "pagination pagination-sm");

                for (int i = 0; i < (int)Math.Ceiling((decimal)TotalCount / PageSize.Value); i++)
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

﻿using Neptuo.TemplateEngine.Web.DataSources;
using Neptuo.Templates;
using SharpKit.jQuery;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class ListViewControl : TemplateControl
    {
        public DataSources.IListDataSource Source { get; set; }
        public ITemplate ItemTemplate { get; set; }
        public ITemplate EmptyTemplate { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        protected DataContextStorage DataContext { get; private set; }
        protected int TotalCount { get; private set; }
        protected IGuidProvider GuidProvider { get; private set; }
        private string partialElementGuid;

        private string partialGuid;

        public ListViewControl(IComponentManager componentManager, TemplateContentStorageStack storage, DataContextStorage dataContext, IGuidProvider guidProvider)
            : base(componentManager, storage) 
        {
            DataContext = dataContext;
            GuidProvider = guidProvider;
        }

        public override void OnInit()
        {
            InitComponent(ItemTemplate);
            if (ItemTemplate == null)
                throw new ArgumentException("Missing item template.", "ItemTemplate");

            InitComponent(Source);
            if (Source == null)
                throw new ArgumentException("Missing data source.", "Source");

            Source.GetData(PageIndex, PageSize, OnLoadData);
            partialElementGuid = GuidProvider.Next();
        }

        public override void Render(IHtmlWriter writer)
        {
            if (!isDataLoaded)
            {
                isRenderCalled = true;
                
                writer
                    .Tag("div")
                    .Attribute("data-partial", partialElementGuid)
                    .Content("Loading data...")
                    .CloseFullTag();

                return;
            }

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

        private bool isRenderCalled = false;
        private bool isDataLoaded = false;
        private void OnLoadData(IListResult result)
        {
            isDataLoaded = true;




            bool isEmpty = true;

            List<object> itemTemplates = new List<object>();

            DataContext.Push(this, "Template");
            TotalCount = result.TotalCount;
            foreach (object model in result.Data)
            {
                isEmpty = false;
                DataContext.Push(model);
                itemTemplates.Add(InitTemplate(ItemTemplate));
                DataContext.Pop();
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

            if (isRenderCalled)
            {
                StringWriter stringWriter = new StringWriter();
                HtmlTextWriter writer = new HtmlTextWriter(stringWriter);

                Render(writer);
                InitScript.UpdateContent(partialElementGuid, stringWriter);
            }
        }
    }
}
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
        public IListDataSource Source { get; set; }
        public ITemplate ItemTemplate { get; set; }
        public ITemplate EmptyTemplate { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        protected IRequestContext RequestContext { get; private set; }
        protected DataContextStorage DataContext { get; private set; }
        protected int TotalCount { get; private set; }
        protected PartialUpdateHelper UpdateHelper { get; private set; }

        public ListViewControl(IRequestContext requestContext, TemplateContentStorageStack storage, DataContextStorage dataContext, PartialUpdateHelper updateHelper)
            : base(requestContext.ComponentManager, storage) 
        {
            RequestContext = requestContext;
            DataContext = dataContext;
            UpdateHelper = updateHelper;
        }

        public override void OnInit()
        {
            InitComponent(ItemTemplate);
            if (ItemTemplate == null)
                throw new ArgumentException("Missing item template.", "ItemTemplate");

            InitComponent(Source);
            if (Source == null)
                throw new ArgumentException("Missing data source.", "Source");

            UpdateHelper.RenderContent += OnRenderContent;
            UpdateHelper.OnInit();

            GetModelPage(PageIndex, PageSize, OnLoadData, OnError);
        }

        protected virtual void GetModelPage(int? pageIndex, int? pageSize, Action<IListResult> callback, Action<ErrorModel> errorCallback)
        {
            Source.GetData(pageIndex, pageSize, callback, errorCallback);
        }

        protected virtual void ProcessModelItem(List<object> itemTemplates, object model)
        {
            DataContext.Push(model);
            itemTemplates.Add(InitTemplate(ItemTemplate));
            DataContext.Pop();
        }

        private void OnRenderContent(IHtmlWriter writer)
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
                            .Attribute("href", GetBaseUrl() + ((i != 0) ? ("?PageIndex=" + i) : "?"))
                            .Content(i + 1)
                            .CloseFullTag()
                        .CloseFullTag();
                }

                writer
                    .CloseFullTag();
            }
        }

        private string GetBaseUrl()
        {
            string currentUrl = RequestContext.GetCurrentUrl();
            int indexOfQueryString = currentUrl.IndexOf('?');
            if (indexOfQueryString > 0)
                currentUrl = currentUrl.Substring(0, indexOfQueryString);

            return currentUrl;
        }

        public override void Render(IHtmlWriter writer)
        {
            UpdateHelper.Render(writer);
        }

        private void OnLoadData(IListResult result)
        {
            bool isEmpty = true;

            List<object> itemTemplates = new List<object>();

            DataContext.Push(this, "Template");
            TotalCount = result.TotalCount;
            foreach (object model in result.Data)
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

            UpdateHelper.OnDataLoaded();
        }

        private void OnError(ErrorModel model)
        {
            UpdateHelper.OnError(model);
        }
    }
}

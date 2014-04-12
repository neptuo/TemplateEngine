using Neptuo.TemplateEngine.Web.DataSources;
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
        public IListDataSource Source { get; set; }
        public ITemplate ItemTemplate { get; set; }
        public ITemplate EmptyTemplate { get; set; }
        public IPaginationControl Pagination { get; set; }
        public int? PageSize { get; set; }
        public int? PageIndex { get; set; }
        protected int TotalCount { get; private set; }
        protected IRequestContext RequestContext { get; private set; }
        protected DataContextStorage DataContext { get; private set; }

        public ListViewControl(IRequestContext requestContext, TemplateContentStorageStack storage, DataContextStorage dataContext)
            : base(requestContext.ComponentManager, storage)
        {
            RequestContext = requestContext;
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

            if (PageSize != null)
                Pagination = new PaginationControl(ComponentManager, RequestContext, TemplateStorageStack);

            if (Pagination != null)
            {
                Pagination.PageIndex = PageIndex ?? 0;
                Pagination.PageSize = PageSize.Value;
                Pagination.TotalCount = TotalCount;
                InitComponent(Pagination);
            }

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
            RenderComponent(Pagination, writer);
        }
    }
}

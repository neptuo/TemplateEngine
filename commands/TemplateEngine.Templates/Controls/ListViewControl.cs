using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Templates.DataSources;
using Neptuo.Templates;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// View that operates on <see cref="IListDataSource"/> and enables rending list of item.
    /// Gets page from list data source and applies <see cref="ItemTemplate"/>.
    /// If no item is in data source, renders <see cref="EmptyTemplate"/>.
    /// Enables paging by setting <see cref="PageSize"/> (and <see cref="PageIndex"/>). For paging uses <see cref="Pagination"/> control.
    /// Each item object is inserted in <see cref="DataContext"/> in init phase.
    /// </summary>
    public class ListViewControl : TemplateControl
    {
        /// <summary>
        /// Data source.
        /// </summary>
        public IListDataSource Source { get; set; }

        /// <summary>
        /// Template for item.
        /// </summary>
        public ITemplate ItemTemplate { get; set; }
        
        /// <summary>
        /// Template when no item is in data source.
        /// </summary>
        public ITemplate EmptyTemplate { get; set; }

        /// <summary>
        /// Pagination control.
        /// </summary>
        public IPaginationControl Pagination { get; set; }

        /// <summary>
        /// Page size.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Page index.
        /// </summary>
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

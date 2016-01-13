using Neptuo.Data.Queries;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.TemplateEngine.Publishing.Data.Queries;
using Neptuo.TemplateEngine.Publishing.ViewModels;
using Neptuo.TemplateEngine.Templates.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Templates.DataSources
{
    [WebDataSource]
    public class ArticleLineDataSource : IListDataSource, IDataSource, IArticleLineDataSourceFilter
    {
        private IArticleLineQuery query;
        private IModelBinder modelBinder;

        public int? Key { get; set; }
        public string Name { get; set; }
        public string UrlPart { get; set; }

        public ArticleLineDataSource(IArticleLineQuery query, IModelBinder modelBinder)
        {
            Guard.NotNull(query, "query");
            Guard.NotNull(modelBinder, "modelBinder");
            this.query = query;
            this.modelBinder = modelBinder;
        }

        protected void ApplyFilter()
        {
            if (Key != null)
                query.Filter.Key = IntSearch.Create(Key.Value);

            if (!String.IsNullOrEmpty(Name))
                query.Filter.Name = TextSearch.StartsWith(Name);

            if (!String.IsNullOrEmpty(UrlPart))
                query.Filter.Url = TextSearch.Create(UrlPart);

            query.OrderBy(l => l.Name);
        }

        public object GetItem()
        {
            ArticleLineEditViewModel viewModel = new ArticleLineEditViewModel();
            if (Key != null)
            {
                query.Filter.Key = IntSearch.Create(Key.Value);
                ArticleLine model = query.ResultSingle();
                if (model == null)
                    viewModel = new ArticleLineEditViewModel();
                else
                    viewModel = new ArticleLineEditViewModel(model.Key, model.Name, model.Url, model.AvailableTags.Select(t => t.Key));
            }

            modelBinder.Bind(viewModel);
            return viewModel;
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            ApplyFilter();

            List<ArticleLineViewModel> result = new List<ArticleLineViewModel>();
            foreach (ArticleLine line in query.EnumeratePageItems(pageIndex, pageSize))
                result.Add(new ArticleLineViewModel(line.Key, line.Name, line.Url));

            return result;  
        }

        public int GetTotalCount()
        {
            ApplyFilter();
            return query.Count();
        }
    }
}

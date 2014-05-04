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
    public class ArticleDataSource : IListDataSource, IDataSource, IArticleDataSourceFilter
    {
        private IModelBinder modelBinder;
        private IArticleQuery query;

        public int? Key { get; set; }
        public int? LineKey { get; set; }
        public int? TagKey { get; set; }
        public string Title { get; set; }
        public string UrlPart { get; set; }
        public bool IsIncludeHidden { get; set; }

        public ArticleDataSource(IArticleQuery query, IModelBinder modelBinder)
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

            if (LineKey != null)
                query.Filter.LineKey = IntSearch.Create(LineKey.Value);

            if (TagKey != null)
                query.Filter.TagKey = IntSearch.Create(TagKey.Value);

            if (!String.IsNullOrEmpty(Title))
                query.Filter.Title = TextSearch.Contains(Title);

            if (!String.IsNullOrEmpty(UrlPart))
                query.Filter.Url = TextSearch.Create(UrlPart);

            if (IsIncludeHidden)
                query.Filter.IsVisible = null;

            query.OrderByDescending(a => a.Title);
        }

        public object GetItem()
        {
            ArticleEditViewModel viewModel = new ArticleEditViewModel();
            if (Key != null)
            {
                query.Filter.IsVisible = null;
                query.Filter.Key = IntSearch.Create(Key.Value);
                Article model = query.ResultSingle();
                viewModel = new ArticleEditViewModel(
                    model.Key, 
                    model.Title, 
                    model.Content, 
                    model.Url, 
                    model.IsVisible, 
                    model.Author, 
                    model.Line.Key, 
                    model.Line.AvailableTags.Select(t => t.Key), 
                    model.Tags.Select(t => t.Key)
                );
            }

            modelBinder.Bind(viewModel);
            return viewModel;
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            ApplyFilter();

            List<ArticleViewModel> result = new List<ArticleViewModel>();
            foreach (Article article in query.EnumeratePageItems(pageIndex, pageSize))
            {
                result.Add(
                    new ArticleViewModel(
                        article.Key,
                        article.Title,
                        article.Content,
                        article.Url,
                        article.IsVisible,
                        article.Author,
                        article.Created,
                        article.LastModified,
                        new ArticleLineViewModel(article.Line.Key, article.Line.Name, article.Line.Url),
                        article.Tags.Select(t => new ArticleTagViewModel(t.Key, t.Name, t.Url))
                    )
                );
            }
            return result;
        }

        public int GetTotalCount()
        {
            ApplyFilter();
            return query.Count();
        }
    }
}

using Neptuo.Data.Queries;
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
        private IArticleQuery query;

        public int? Key { get; set; }
        public int? LineKey { get; set; }
        public int? TagKey { get; set; }
        public string Url { get; set; }
        public bool? IsVisible { get; set; }

        public ArticleDataSource(IArticleQuery query)
        {
            Guard.NotNull(query, "query");
            this.query = query;
        }

        protected void ApplyFilter()
        {
            if (Key != null)
                query.Filter.Key = IntSearch.Create(Key.Value);

            if (LineKey != null)
                query.Filter.LineKey = IntSearch.Create(LineKey.Value);

            if (TagKey != null)
                query.Filter.TagKey = IntSearch.Create(TagKey.Value);

            if (!String.IsNullOrEmpty(Url))
                query.Filter.Url = TextSearch.Create(Url);

            if (IsVisible != null)
                query.Filter.IsVisible = BoolSearch.Create(IsVisible.Value);
        }

        public object GetItem()
        {
            if (Key != null)
            {
                query.Filter.Key = IntSearch.Create(Key.Value);
                return query.ResultSingle();
            }
            return null;
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

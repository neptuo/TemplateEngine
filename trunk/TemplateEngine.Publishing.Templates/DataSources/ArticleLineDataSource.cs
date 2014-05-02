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
    public class ArticleLineDataSource : IListDataSource, IDataSource, IArticleLineDataSourceFilter
    {
        private IArticleLineQuery query;

        public int? Key { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public ArticleLineDataSource(IArticleLineQuery query)
        {
            Guard.NotNull(query, "query");
            this.query = query;
        }

        protected void ApplyFilter()
        {
            if (Key != null)
                query.Filter.Key = IntSearch.Create(Key.Value);

            if (!String.IsNullOrEmpty(Name))
                query.Filter.Name = TextSearch.Contains(Name, false);

            if (!String.IsNullOrEmpty(Url))
                query.Filter.Url = TextSearch.Create(Url);
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

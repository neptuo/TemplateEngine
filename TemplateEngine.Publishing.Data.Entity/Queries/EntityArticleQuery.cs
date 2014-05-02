using Neptuo.Data.Entity.Queries;
using Neptuo.TemplateEngine.Publishing.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Data.Entity.Queries
{
    public class EntityArticleQuery : EntityQuery<Article, IArticleFilter>, IArticleQuery
    {
        protected override Expression BuildWhereExpression(ParameterExpression parameter)
        {
            Expression target = null;
            if (Filter != null)
            {
                if (Filter.Key != null)
                    target = EntityQuerySearch.BuildIntSearch<Article>(target, parameter, a => a.Key, Filter.Key);

                if (Filter.Title != null)
                    target = EntityQuerySearch.BuildTextSearch<Article>(target, parameter, a => a.Title, Filter.Title);

                if(Filter.Url != null)
                    target = EntityQuerySearch.BuildTextSearch<Article>(target, parameter, a => a.Url, Filter.Url);

                if (Filter.IsVisible != null)
                    target = EntityQuerySearch.BuildBoolSearch<Article>(target, parameter, a => a.IsVisible, Filter.IsVisible);

                if (Filter.LineKey != null)
                    target = EntityQuerySearch.BuildIntSearch<Article>(target, parameter, a => a.Line.Key, Filter.LineKey);
            }
            return target;
        }

        protected override IArticleFilter CreateFilter()
        {
            return new ArticleFilter();
        }
    }
}

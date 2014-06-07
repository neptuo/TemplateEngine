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
    public class EntityArticleLineQuery : EntityQuery<ArticleLine, IArticleLineFilter>, IArticleLineQuery
    {
        public EntityArticleLineQuery(DataContext dbContext)
            : base(dbContext.ArticleLines)
        { }

        protected override Expression BuildWhereExpression(ParameterExpression parameter)
        {
            Expression target = null;
            if (Filter != null)
            {
                if (Filter.Key != null)
                    target = EntityQuerySearch.BuildIntSearch<ArticleLine>(target, parameter, l => l.Key, Filter.Key);

                if (Filter.Name != null)
                    target = EntityQuerySearch.BuildTextSearch<ArticleLine>(target, parameter, l => l.Name, Filter.Name);

                if (Filter.Url != null)
                    target = EntityQuerySearch.BuildTextSearch<ArticleLine>(target, parameter, l => l.Url, Filter.Url);
            }
            return target;
        }

        protected override IArticleLineFilter CreateFilter()
        {
            return new ArticleLineFilter();
        }
    }
}

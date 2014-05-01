using Neptuo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Data.Entity
{
    public class EntityArticleLineRepository : EntityRepository<ArticleLine, DataContext>, IArticleLineRepository
    {
        public EntityArticleLineRepository(DataContext dbContext)
            : base(dbContext)
        { }

        public ArticleLine Create()
        {
            return DbContext.ArticleLines.Create();
        }
    }
}

using Neptuo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Data.Entity
{
    public class EntityArticleTagRepository : EntityRepository<ArticleTag, DataContext>, IArticleTagRepository
    {
        public EntityArticleTagRepository(DataContext dbContext)
            : base(dbContext)
        { }

        public ArticleTag Create()
        {
            return DbContext.ArticleTags.Create();
        }
    }
}

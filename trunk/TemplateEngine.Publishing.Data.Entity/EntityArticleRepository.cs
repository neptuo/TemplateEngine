using Neptuo.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Data.Entity
{
    public class EntityArticleRepository : EntityRepository<Article, DataContext>, IArticleRepository
    {
        public EntityArticleRepository(DataContext dbContext)
            : base(dbContext)
        { }

        public Article Create()
        {
            return DbContext.Articles.Create();
        }
    }
}

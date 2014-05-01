using Neptuo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Data
{
    public interface IArticleTagRepository : IRepository<ArticleTag>, IActivator<ArticleTag>
    { }
}

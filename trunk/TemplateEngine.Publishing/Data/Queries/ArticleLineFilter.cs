using Neptuo.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Data.Queries
{
    public class ArticleLineFilter : IArticleLineFilter
    {
        public IntSearch Key { get; set; }
        public TextSearch Name { get; set; }
        public TextSearch Url { get; set; }
    }
}

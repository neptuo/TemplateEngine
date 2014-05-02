using Neptuo.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Data.Queries
{
    public class ArticleFilter : IArticleFilter
    {
        public IntSearch Key { get; set; }
        public TextSearch Title { get; set; }
        public TextSearch Url { get; set; }
        public BoolSearch IsVisible { get; set; }
        
        public IntSearch LineKey { get; set; }
        public IntSearch TagKey { get; set; }

        public ArticleFilter()
        {
            IsVisible = BoolSearch.True();
        }
    }
}

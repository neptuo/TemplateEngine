using Neptuo.TemplateEngine.Templates.DataSources;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Templates.DataSources
{
    public class ArticleDataSource : DynamicListDataSourceProxy<ModelValueGetterListResult>, IArticleDataSourceFilter
    {
        public int? Key { get; set; }
        public int? LineKey { get; set; }
        public int? TagKey { get; set; }
        public bool IsIncludeHidden { get; set; }
        
        public string Title { get; set; }
        public string UrlPart { get; set; }

        public ArticleDataSource(IVirtualUrlProvider urlProvider)
            : base(urlProvider, GetFilterProperties())
        { }

        private static IEnumerable<string> GetFilterProperties()
        {
            return new List<string> { "Key", "LineKey", "TagKey", "IsIncludeHidden", "Title", "UrlPart", };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Templates.DataSources
{
    public interface IArticleDataSourceFilter
    {
        int? Key { get; set; }
        int? LineKey { get; set; }
        int? TagKey { get; set; }

        string Url { get; set; }
    }
}

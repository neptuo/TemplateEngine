using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Templates.DataSources
{
    public interface IArticleTagDataSourceFilter
    {
        IEnumerable<int> Key { get; set; }
        string Name { get; set; }
        string Url { get; set; }
    }
}

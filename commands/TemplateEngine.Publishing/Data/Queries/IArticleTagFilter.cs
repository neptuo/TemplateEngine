using Neptuo.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Data.Queries
{
    public interface IArticleTagFilter
    {
        IntSearch Key { get; set; }
        TextSearch Name { get; set; }
        TextSearch Url { get; set; }
    }
}

using Neptuo.TemplateEngine.Templates.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing
{
    public class ArticleTagListResult : ListResult
    {
        public ArticleTagListResult(IEnumerable data, int totalCount)
            : base(data, totalCount)
        { }
    }
}

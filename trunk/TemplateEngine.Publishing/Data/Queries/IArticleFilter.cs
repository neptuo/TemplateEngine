using Neptuo.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Data.Queries
{
    public interface IArticleFilter
    {
        IntSearch Key { get; set; }
        TextSearch Title { get; set; }
        TextSearch Url { get; set; }
        BoolSearch IsVisible { get; set; }

        IntSearch LineKey { get; set; }
        IntSearch TagKey { get; set; }
    }
}

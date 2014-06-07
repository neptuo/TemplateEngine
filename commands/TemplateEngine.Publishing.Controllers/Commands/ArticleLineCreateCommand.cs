using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Controllers.Commands
{
    public class ArticleLineCreateCommand
    {
        public string Name { get; set; }
        public string UrlPart { get; set; }
        public IEnumerable<int> AvailableTagKeys { get; set; }
    }
}

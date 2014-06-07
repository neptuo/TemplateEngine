using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Controllers.Commands
{
    public class ArticleCreateCommand
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string UrlPart { get; set; }
        public bool IsVisible { get; set; }

        public string Author { get; set; }

        public int LineKey { get; set; }
        public IEnumerable<int> TagKeys { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.ViewModels
{
    public class ArticleTagViewModel
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public string UrlPart { get; set; }

        public ArticleTagViewModel()
        { }

        public ArticleTagViewModel(int key, string name, string urlPart)
        {
            Key = key;
            Name = name;
            UrlPart = urlPart;
        }
    }
}

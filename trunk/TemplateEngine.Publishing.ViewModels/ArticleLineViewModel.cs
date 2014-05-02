using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.ViewModels
{
    public class ArticleLineViewModel
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public ArticleLineViewModel(int key, string name, string url)
        {
            Key = key;
            Name = name;
            Url = url;
        }
    }
}

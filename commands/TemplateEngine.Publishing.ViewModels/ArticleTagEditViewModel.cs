using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.ViewModels
{
    public class ArticleTagEditViewModel
    {
        public bool IsNew
        {
            get { return Key == null; }
        }

        public int? Key { get; set; }
        public string Name { get; set; }
        public string UrlPart { get; set; }

        public ArticleTagEditViewModel()
        { }

        public ArticleTagEditViewModel(int? key, string name, string urlPart)
        {
            Key = key;
            Name = name;
            UrlPart = urlPart;
        }
    }
}

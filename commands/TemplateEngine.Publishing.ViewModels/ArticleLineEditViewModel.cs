using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.ViewModels
{
    public class ArticleLineEditViewModel
    {
        public bool IsNew
        {
            get { return Key == null; }
        }

        public int? Key { get; set; }
        public string Name { get; set; }
        public string UrlPart { get; set; }
        public IEnumerable<int> AvailableTagKeys { get; set; }

        public ArticleLineEditViewModel()
        { }

        public ArticleLineEditViewModel(int? key, string name, string urlPart, IEnumerable<int> availableTagKeys)
        {
            Key = key;
            Name = name;
            UrlPart = urlPart;
            AvailableTagKeys = availableTagKeys;
        }
    }
}

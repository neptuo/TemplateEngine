using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.ViewModels
{
    public class ArticleEditViewModel
    {
        public bool IsNew
        {
            get { return Key == null; }
        }

        public int? Key { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string UrlPart { get; set; }
        public bool IsVisible { get; set; }

        public string Author { get; set; }

        public int LineKey { get; set; }
        public IEnumerable<int> AvailableTagKeys { get; set; }
        public IEnumerable<int> TagKeys { get; set; }

        public ArticleEditViewModel()
        { }

        public ArticleEditViewModel(int key, string title, string content, string urlPart, bool isVisible, string author, int lineKey, IEnumerable<int> availableTagKeys, IEnumerable<int> tagKeys)
        {
            Key = key;
            Title = title;
            Content = content;
            UrlPart = urlPart;
            IsVisible = isVisible;
            Author = author;
            LineKey = lineKey;
            AvailableTagKeys = availableTagKeys;
            TagKeys = tagKeys;
        }
    }
}

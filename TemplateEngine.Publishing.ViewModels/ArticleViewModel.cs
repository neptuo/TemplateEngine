using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.ViewModels
{
    public class ArticleViewModel
    {
        public int Key { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public bool IsVisible { get; set; }

        public string Author { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        public ArticleLineViewModel Line { get; set; }
        public IEnumerable<ArticleTagViewModel> Tags { get; set; }

        public ArticleViewModel(int key, string title, string content, string url, bool isVisible, string author, DateTime created, DateTime? lastModified, ArticleLineViewModel line, IEnumerable<ArticleTagViewModel> tags)
        {
            Key = key;
            Title = title;
            Content = content;
            Url = url;
            IsVisible = isVisible;
            Author = author;
            Created = created;
            LastModified = lastModified;
            Line = line;
            Tags = tags;
        }
    }
}

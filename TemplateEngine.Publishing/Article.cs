using Neptuo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing
{
    public class Article : IKey<int>, IVersion
    {
        public int Key { get; set; }
        public byte[] Version { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public bool IsVisible { get; set; }

        public string Author { get; set; }

        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }

        public virtual ArticleLine Line { get; set; }
        public virtual ICollection<ArticleTag> Tags { get; set; }
    }
}

using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    public static class HtmlWriterExtensions
    {
        public static IHtmlWriter Script(this IHtmlWriter writer, string path)
        {
            return writer
                .Tag("script")
                .Attribute("src", path)
                .CloseFullTag();
        }

        public static IHtmlWriter Style(this IHtmlWriter writer, string path)
        {
            return writer
                .Tag("link")
                .Attribute("href", path)
                .Attribute("rel", "stylesheet")
                .CloseTag();
        }
    }
}

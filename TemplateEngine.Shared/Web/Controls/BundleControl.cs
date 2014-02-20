using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class BundleControl : IControl
    {
        private IVirtualUrlProvider urlProvider;

        public string Path { get; set; }

        public BundleControl(IVirtualUrlProvider urlProvider)
        {
            this.urlProvider = urlProvider;
        }

        public void OnInit()
        {
            Guard.NotNull(Path, "Path");
        }

        public void Render(IHtmlWriter writer)
        {
            writer
                .Tag("script")
                .Attribute("src", urlProvider.ResolveUrl(Path))
                .CloseFullTag();
        }
    }
}

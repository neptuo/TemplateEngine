using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class BundleControlBase : IControl
    {
        private IVirtualUrlProvider urlProvider;

        public bool IsStyle { get; set; }
        public string Path { get; set; }

        public BundleControlBase(IVirtualUrlProvider urlProvider)
        {
            this.urlProvider = urlProvider;
        }

        public void OnInit()
        {
            Guard.NotNull(Path, "Path");
        }

        public void Render(IHtmlWriter writer)
        {
            if (IsStyle)
                RenderStyle(writer);
            else
                RenderScript(writer);
        }

        protected virtual void RenderScript(IHtmlWriter writer)
        {
            writer.Script(urlProvider.ResolveUrl(Path));
        }

        protected virtual void RenderStyle(IHtmlWriter writer)
        {
            writer.Style(urlProvider.ResolveUrl(Path));
        }
    }
}

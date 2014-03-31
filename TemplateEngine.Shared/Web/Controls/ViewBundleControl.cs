using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class ViewBundleControl : IControl
    {
        private IVirtualUrlProvider urlProvider;

        public string Path { get; set; }

        public ViewBundleControl(IVirtualUrlProvider urlProvider)
        {
            this.urlProvider = urlProvider;
        }

        public void OnInit()
        { }

        public void Render(IHtmlWriter writer)
        {
            writer
                .Tag("script")
                .Attribute("src", urlProvider.ResolveUrl(String.Format("~/Views.ashx?Path={0}", Path)))
                .CloseFullTag();
        }
    }
}

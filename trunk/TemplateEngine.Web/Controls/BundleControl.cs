using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class BundleControl : IControl
    {
        private IVirtualUrlProvider urlProvider;
        private HttpContextBase httpContext;
        private BundleCollection bundles;
        private bool enableOptimizations;

        public string Path { get; set; }

        public BundleControl(IVirtualUrlProvider urlProvider, HttpContextBase httpContext)
        {
            this.urlProvider = urlProvider;
            this.httpContext = httpContext;
            this.bundles = BundleTable.Bundles;
            this.enableOptimizations = BundleTable.EnableOptimizations;
        }

        public void OnInit()
        {
            Guard.NotNull(Path, "Path");
        }

        public void Render(IHtmlWriter writer)
        {
            if (enableOptimizations)
            {
                writer
                    .Tag("script")
                    .Attribute("src", urlProvider.ResolveUrl(Path))
                    .CloseFullTag();
            }
            else
            {
                Bundle bundle = bundles.GetBundleFor(Path);
                if (bundle != null)
                {
                    foreach (BundleFile bundleFile in bundle.EnumerateFiles(new BundleContext(httpContext, bundles, Path)))
                    {
                        writer
                            .Tag("script")
                            .Attribute("src", urlProvider.ResolveUrl(bundleFile.IncludedVirtualPath))
                            .CloseFullTag();
                    }
                }

            }
        }
    }
}

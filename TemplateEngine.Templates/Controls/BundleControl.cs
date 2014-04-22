using Neptuo.TemplateEngine.Configuration;
using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Optimization;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class BundleControl : BundleControlBase
    {
        private IVirtualUrlProvider urlProvider;
        private HttpContextBase httpContext;
        private BundleCollection bundles;
        private bool enableOptimizations;

        public BundleControl(IApplicationConfiguration config, IVirtualUrlProvider urlProvider, HttpContextBase httpContext)
            : base(urlProvider)
        {
            this.urlProvider = urlProvider;
            this.httpContext = httpContext;
            this.bundles = BundleTable.Bundles;
            this.enableOptimizations = !config.IsDebug;
        }

        protected IEnumerable<BundleFile> GetBundleContent()
        {
            Bundle bundle = bundles.GetBundleFor(Path);
            if (bundle == null)
                return Enumerable.Empty<BundleFile>();

            return bundle.EnumerateFiles(new BundleContext(httpContext, bundles, Path));
        }

        protected override void RenderScript(IHtmlWriter writer)
        {
            if (enableOptimizations)
            {
                base.RenderScript(writer);
                return;
            }

            foreach (BundleFile bundleFile in GetBundleContent())
                writer.Script(urlProvider.ResolveUrl(bundleFile.IncludedVirtualPath));
        }

        protected override void RenderStyle(IHtmlWriter writer)
        {
            if (enableOptimizations)
            {
                base.RenderStyle(writer);
                return;
            }

            foreach (BundleFile bundleFile in GetBundleContent())
                writer.Style(urlProvider.ResolveUrl(bundleFile.IncludedVirtualPath));
        }
    }
}

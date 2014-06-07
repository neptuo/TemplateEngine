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
    /// <summary>
    /// Enables inclusion of <see cref="Bundle"/> in view.
    /// </summary>
    public class BundleControl : BundleControlBase
    {
        private IApplicationConfiguration config;
        private IVirtualUrlProvider urlProvider;
        private HttpContextBase httpContext;
        private BundleCollection bundles;

        public BundleControl(IApplicationConfiguration config, IVirtualUrlProvider urlProvider, HttpContextBase httpContext)
            : base(urlProvider)
        {
            this.config = config;
            this.urlProvider = urlProvider;
            this.httpContext = httpContext;
            this.bundles = BundleTable.Bundles;
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
            if (!config.IsDebug)
            {
                base.RenderScript(writer);
                return;
            }

            foreach (BundleFile bundleFile in GetBundleContent())
                writer.Script(urlProvider.ResolveUrl(bundleFile.IncludedVirtualPath));
        }

        protected override void RenderStyle(IHtmlWriter writer)
        {
            if (!config.IsDebug)
            {
                base.RenderStyle(writer);
                return;
            }

            foreach (BundleFile bundleFile in GetBundleContent())
                writer.Style(urlProvider.ResolveUrl(bundleFile.IncludedVirtualPath));
        }
    }
}

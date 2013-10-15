using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public abstract class GeneratedViewBase : BaseGeneratedView
    {
        protected IVirtualUrlProvider urlProvider;

        public string ResolveUrl(string relativeUrl)
        {
            if (urlProvider == null)
                urlProvider = dependencyProvider.Resolve<IVirtualUrlProvider>();

            return urlProvider.ResolveUrl(relativeUrl);
        }
    }
}

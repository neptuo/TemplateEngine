using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        protected override T CastValueTo<T>(object value)
        {
            return (T)value;
        }
    }
}

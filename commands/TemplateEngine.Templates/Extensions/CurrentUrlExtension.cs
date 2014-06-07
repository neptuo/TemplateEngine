using Neptuo.TemplateEngine.Providers;
using Neptuo.Templates.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Templates.Extensions
{
    /// <summary>
    /// Returns current url.
    /// </summary>
    public class CurrentUrlExtension : IValueExtension
    {
        private ICurrentUrlProvider provider;

        public CurrentUrlExtension(ICurrentUrlProvider provider)
        {
            this.provider = provider;
        }

        public object ProvideValue(IValueExtensionContext context)
        {
            return provider.GetCurrentUrl();
        }
    }
}

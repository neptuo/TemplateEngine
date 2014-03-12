using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    public class ClientNavigateTo : QueryStringNavigateTo
    {
        private Action<string> navigateToUrl;

        public ClientNavigateTo(IVirtualUrlProvider urlProvider, FormUri formUri, Action<string> navigateToUrl)
            : base(urlProvider, formUri)
        {
            Guard.NotNull(navigateToUrl, "navigateToUrl");
            this.navigateToUrl = navigateToUrl;
        }

        protected override void NavigateToUrl(string url)
        {
            navigateToUrl(url);
        }
    }
}

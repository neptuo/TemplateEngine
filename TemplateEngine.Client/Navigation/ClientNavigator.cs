using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    public class ClientNavigator : INavigator
    {
        private IVirtualUrlProvider urlProvider;
        private Action<string> navigateToUrl;

        public ClientNavigator(IVirtualUrlProvider urlProvider, Action<string> navigateToUrl)
        {
            Guard.NotNull(urlProvider, "urlProvider");
            Guard.NotNull(navigateToUrl, "navigateToUrl");

            this.urlProvider = urlProvider;
            this.navigateToUrl = navigateToUrl;
        }

        public void Open(FormUri formUri)
        {
            NavigateTo(formUri).Open();
        }

        public INavigateTo NavigateTo(FormUri formUri)
        {
            return new ClientNavigateTo(urlProvider, formUri, navigateToUrl);
        }
    }
}

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

        public ClientNavigator(IVirtualUrlProvider urlProvider)
        {
            this.urlProvider = urlProvider;
        }

        public void Open(FormUri formUri)
        {
            NavigateTo(formUri).Open();
        }

        public INavigateTo NavigateTo(FormUri formUri)
        {
            return new ClientNavigateTo(urlProvider, formUri);
        }
    }
}

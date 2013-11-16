using Neptuo.TemplateEngine.Navigation;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web.Navigation
{
    public class RedirectNavigator : INavigator
    {
        private IVirtualUrlProvider urlProvider;
        private HttpContextBase httpContext;

        public RedirectNavigator(IVirtualUrlProvider urlProvider, HttpContextBase httpContext)
        {
            this.urlProvider = urlProvider;
            this.httpContext = httpContext;
        }

        public void Open(FormUri formUri)
        {
            new RedirectNavigateTo(urlProvider, httpContext, formUri).Open();
        }

        public INavigateTo NavigateTo(FormUri formUri)
        {
            return new RedirectNavigateTo(urlProvider, httpContext, formUri);
        }
    }
}

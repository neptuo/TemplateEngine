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
    /// <summary>
    /// Server redirect <see cref="INavigateTo"/> implementation.
    /// </summary>
    public class RedirectNavigateTo : QueryStringNavigateTo
    {
        private HttpContextBase httpContext;

        public RedirectNavigateTo(IVirtualUrlProvider urlProvider, HttpContextBase httpContext, FormUri formUri)
            : base(urlProvider, formUri)
        {
            this.httpContext = httpContext;
        }

        protected override void NavigateToUrl(string url)
        {
            httpContext.Response.Redirect(url);
        }
    }
}

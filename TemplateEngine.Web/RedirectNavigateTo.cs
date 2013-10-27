using Neptuo.TemplateEngine.Navigation;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web
{
    public class RedirectNavigateTo : INavigateTo
    {
        private IVirtualUrlProvider urlProvider;
        private HttpContextBase httpContext;
        private FormUri formUri;
        private Dictionary<string, object> parameters = new Dictionary<string, object>();

        public RedirectNavigateTo(IVirtualUrlProvider urlProvider, HttpContextBase httpContext, FormUri formUri)
        {
            this.urlProvider = urlProvider;
            this.httpContext = httpContext;
            this.formUri = formUri;
        }

        public void Param(string key, object value)
        {
            parameters[key] = value;
        }

        public void Open()
        {
            StringBuilder queryBuilder = new StringBuilder();
            foreach (KeyValuePair<string, object> parameter in parameters)
                AppendQuery(queryBuilder, parameter.Key, parameter.Value);

            httpContext.Response.Redirect(
                String.Format("{0}{1}", 
                    urlProvider.ResolveUrl(formUri.Url()), 
                    queryBuilder.ToString()
                )
            );
        }

        private void AppendQuery(StringBuilder builder, string key, object value)
        {
            builder.AppendFormat(
                "{2}{0}={1}", 
                key, 
                value, 
                builder.Length == 0 ? "?" : "&"
            );
        }
    }
}

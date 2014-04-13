using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Navigation
{
    public abstract class QueryStringNavigateTo : INavigateTo
    {
        private IVirtualUrlProvider urlProvider;
        private FormUri formUri;
        private Dictionary<string, object> parameters = new Dictionary<string, object>();

        public QueryStringNavigateTo(IVirtualUrlProvider urlProvider, FormUri formUri)
        {
            this.urlProvider = urlProvider;
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

            string targetUrl = String.Format("{0}{1}",
                urlProvider.ResolveUrl(formUri.Url()),
                queryBuilder.ToString()
            );
            NavigateToUrl(targetUrl);
        }

        protected abstract void NavigateToUrl(string url);

        protected void AppendQuery(StringBuilder builder, string key, object value)
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

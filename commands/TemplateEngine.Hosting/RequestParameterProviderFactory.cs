using Neptuo.TemplateEngine.Providers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Hosting
{
    /// <summary>
    /// Parameter provider factory for <see cref="HttpRequestBase"/>.
    /// </summary>
    public class RequestParameterProviderFactory : IParameterProviderFactory
    {
        private HttpRequestBase httpRequest;

        public RequestParameterProviderFactory(HttpRequestBase httpRequest)
        {
            this.httpRequest = httpRequest;
        }

        public IParameterProvider Provider(ParameterProviderType providerType)
        {
            switch (providerType)
            {
                case ParameterProviderType.All:
                    return new InternalParameterProvider(httpRequest.Params);
                case ParameterProviderType.Url:
                    return new InternalParameterProvider(httpRequest.QueryString);
                case ParameterProviderType.Form:
                    return new InternalParameterProvider(httpRequest.Form);
                default:
                    throw new NotSupportedException();
            }
        }

        private class InternalParameterProvider : IParameterProvider
        {
            private NameValueCollection parameters;

            public IEnumerable<string> Keys
            {
                get { return parameters.AllKeys; }
            }

            public InternalParameterProvider(NameValueCollection parameters)
            {
                this.parameters = parameters;
            }

            public bool TryGet(string key, out object value)
            {
                if (parameters.AllKeys.Contains(key))
                {
                    value = parameters.Get(key);
                    return true;
                }

                value = null;
                return false;
            }
        }

    }
}

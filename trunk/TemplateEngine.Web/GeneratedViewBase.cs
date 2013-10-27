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
        protected HttpContextBase httpContext;

        public string ResolveUrl(string relativeUrl)
        {
            if (urlProvider == null)
                urlProvider = dependencyProvider.Resolve<IVirtualUrlProvider>();

            return urlProvider.ResolveUrl(relativeUrl);
        }

        public T ValueFromRequest<T>(string key)
        {
            if (httpContext == null)
                httpContext = dependencyProvider.Resolve<HttpContextBase>();

            if (!httpContext.Request.Params.AllKeys.Contains(key))
                return default(T);

            object value = httpContext.Request.Params[key];
            Type targetType = typeof(T);
            TypeConverter typeConverter = TypeDescriptor.GetConverter(targetType);
            if (!typeConverter.CanConvertFrom(value.GetType()))
                return default(T);

            return (T)typeConverter.ConvertFrom(value);
        }
    }
}

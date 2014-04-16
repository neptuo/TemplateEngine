using Neptuo.PresentationModels;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Templates
{
    public abstract class GeneratedViewBase : BaseGeneratedView
    {
        protected IVirtualUrlProvider urlProvider;
        protected HttpContextBase httpContext;
        protected IBindingConverterCollection bindingConverters;

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

        protected override T CastValueTo<T>(object value)
        {
            if (value == null)
                return default(T);

            Type sourceType = value.GetType();
            Type targetType = typeof(T);

            if (targetType.IsAssignableFrom(sourceType))
                return (T)value;

            if (sourceType == typeof(string))
            {
                if (bindingConverters == null)
                    bindingConverters = dependencyProvider.Resolve<IBindingConverterCollection>();

                IFieldDefinition field = new FieldDefinition(String.Empty, new TypeFieldType(targetType), new MetadataCollection());
                object targetValue;
                if (bindingConverters.TryConvert(value.ToString(), field, out targetValue))
                    return (T)targetValue;
            }

            return base.CastValueTo<T>(value);
        }
    }
}

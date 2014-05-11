using Neptuo.Templates;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Templates
{
    /// <summary>
    /// Javascript implementation of <see cref="GeneratedViewBase"/>.
    /// </summary>
    public abstract class ClientGeneratedViewBase : BaseGeneratedView
    {
        protected IVirtualUrlProvider urlProvider;

        public string ResolveUrl(string relativeUrl)
        {
            if (urlProvider == null)
                urlProvider = dependencyProvider.Resolve<IVirtualUrlProvider>();

            return urlProvider.ResolveUrl(relativeUrl);
        }

        protected override T CastValueTo<T>(object value)
        {
            if (value == null)
                return default(T);

            Type sourceType = value.GetType();
            Type targetType = typeof(T);

            if (sourceType == targetType)
                return (T)value;

            if (targetType == typeof(string))
                return value.ToString().As<T>();

            return value.As<T>();
        }
    }
}

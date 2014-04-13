using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Web;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    public class CompositeRequestContext : IRequestContext
    {
        private ICurrentUrlProvider currentUrl;
        private IVirtualUrlProvider urlProvider;
        private IParameterProviderFactory parameterFactory;

        public IComponentManager ComponentManager { get; private set; }

        public CompositeRequestContext(IComponentManager componentManager, ICurrentUrlProvider currentUrl, IVirtualUrlProvider urlProvider, IParameterProviderFactory parameterFactory)
        {
            Guard.NotNull(componentManager, "componentManager");
            Guard.NotNull(currentUrl, "currentUrl");
            Guard.NotNull(urlProvider, "urlProvider");
            Guard.NotNull(parameterFactory, "parameterFactory");

            ComponentManager = componentManager;
            this.currentUrl = currentUrl;
            this.urlProvider = urlProvider;
            this.parameterFactory = parameterFactory;
        }

        public string GetCurrentUrl()
        {
            return currentUrl.GetCurrentUrl();
        }

        public string ResolveUrl(string path)
        {
            return urlProvider.ResolveUrl(path);
        }

        public IParameterProvider Provider(ParameterProviderType providerType)
        {
            return parameterFactory.Provider(providerType);
        }
    }
}

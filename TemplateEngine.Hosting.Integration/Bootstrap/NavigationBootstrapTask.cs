using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Navigation;
using Neptuo.TemplateEngine.Web.Routing;
using Neptuo.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Integration.Bootstrap
{
    public class NavigationBootstrapTask : IBootstrapTask
    {
        private IDependencyContainer dependencyContainer;

        public NavigationBootstrapTask(IDependencyContainer dependencyContainer)
        {
            this.dependencyContainer = dependencyContainer;
        }

        public void Initialize()
        {
            FormUriTable.Registry
                .Register("Home", TemplateRouteParameterBase.FormatUrl("~/Default"));

            dependencyContainer
                .RegisterInstance<IFormUriRepository>(FormUriTable.Repository)
                .RegisterInstance<IFormUriRegistry>(FormUriTable.Registry)
                .RegisterType<INavigator, RedirectNavigator>(new PerRequestLifetime())
                .RegisterInstance(new GlobalNavigationCollection());
        }
    }
}

using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Web;
using Neptuo.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Backend
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
            DefaultFormUriService formService = new DefaultFormUriService();
            FormUriServiceRegistration.SetInstance(formService);

            formService
                .Register("Home", "~/Home.aspx");

            dependencyContainer
                .RegisterInstance<IFormUriService>(formService)
                .RegisterInstance<IFormUriRegistry>(formService)
                .RegisterType<INavigator, RedirectNavigator>(new PerRequestLifetime());
        }
    }
}

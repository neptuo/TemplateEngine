using log4net;
using log4net.Config;
using Microsoft.Practices.Unity;
using Neptuo;
using Neptuo.Bootstrap;
using Neptuo.Data;
using Neptuo.Data.Entity;
using Neptuo.Events;
using Neptuo.Lifetimes;
using Neptuo.Lifetimes.Mapping;
using Neptuo.TemplateEngine.Accounts.Bootstrap;
using Neptuo.TemplateEngine.Accounts.Data.Entity;
using Neptuo.TemplateEngine.Backend.Bootstrap;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Web.DataSources;
using Neptuo.TemplateEngine.Web.ViewBundles;
using Neptuo.Templates;
using Neptuo.Unity;
using Neptuo.Unity.Lifetimes.Mapping;
using Neptuo.Unity.Web.Lifetimes.Mapping;
using Neptuo.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Security;
using Neptuo.Validation;

namespace Neptuo.TemplateEngine.Backend.UI
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            IDependencyContainer container = CreateDependencyContainer();
            ManualBootstrapper bootstrapper = CreateBootstrapper(container);

            RegisterBootstrapTasks(bootstrapper, container);
            bootstrapper.Initialize();

            Converts.Repository.Add(typeof(string), typeof(int), new StringToIntConverter());
            XmlConfigurator.Configure();
        }

        protected void RegisterBootstrapTasks(IBootstrapTaskRegistry bootstrapper, IDependencyContainer container)
        {
            bootstrapper.Register<ViewServiceBootstrapTask>();
            bootstrapper.Register<RoutingBootstrapTask>();
            bootstrapper.Register<NavigationBootstrapTask>();
            bootstrapper.Register<PresentationModelBootstrapTask>();
            bootstrapper.Register<BindingBootstrapTask>();
            bootstrapper.Register<ViewBundleBootstrapTask>();
            bootstrapper.Register<JavascriptBootstrapTask>();

            //TODO: Bootstrap as independent module
            bootstrapper.Register<AccountBootstrapTask>();
        }

        protected virtual IDependencyContainer CreateDependencyContainer()
        {
            UnityDependencyContainer dependencyContainer = new UnityDependencyContainer()
                .Map(typeof(SingletonLifetime), new SingletonLifetimeMapper())
                .Map(typeof(GetterLifetime), new GetterLifetimeMapper())
                .Map(typeof(PerRequestLifetime), new PerRequestLifetimeMapper())
                .Map(typeof(PerSessionLifetime), new PerSessionLifetimeMapper());

            EventDispatcher eventDispatcher = new EventDispatcher();

            dependencyContainer
                .RegisterType<HttpContextBase>(new GetterLifetime(() => new HttpContextWrapper(HttpContext.Current)))
                .RegisterType<HttpRequestBase>(new GetterLifetime(() => new HttpRequestWrapper(HttpContext.Current.Request)))
                .RegisterInstance<IEventDispatcher>(eventDispatcher)
                .RegisterInstance<IEventRegistry>(eventDispatcher)
                .RegisterInstance<IEventManager>(eventDispatcher)
                .RegisterType<IValidatorService, DependencyValidatorService>()
                .RegisterType<IParameterProvider, RequestParameterProvider>(new PerRequestLifetime())
                .RegisterType<IControllerRegistry>(new SingletonLifetime(new ControllerRegistryBase()))
                .RegisterType<IPermissionProvider, OptimisticPermissionProvider>(new PerRequestLifetime())
                .RegisterInstance<IWebDataSourceRegistry>(new DictionaryWebDataSourceRegistry());

            //TODO: Move to accounts
            dependencyContainer
                .RegisterType<IUnitOfWorkFactory, DbContextUnitOfWorkFactory<DataContext>>(new PerRequestLifetime());

            return dependencyContainer;
        }

        protected virtual SequenceBootstrapper CreateBootstrapper(IDependencyContainer container)
        {
            return new SequenceBootstrapper(type => (IBootstrapTask)container.Resolve(type));
        }

        //protected void Session_Start(object sender, EventArgs e)
        //{

        //}

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{

        //}

        //protected void Application_AuthenticateRequest(object sender, EventArgs e)
        //{

        //}

        protected void Application_Error(object sender, EventArgs e)
        {
            LogManager.GetLogger("Global").Fatal(null, Server.GetLastError());
        }

        //protected void Session_End(object sender, EventArgs e)
        //{

        //}

        //protected void Application_End(object sender, EventArgs e)
        //{

        //}
    }
}
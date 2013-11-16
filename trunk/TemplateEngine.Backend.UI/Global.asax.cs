using Microsoft.Practices.Unity;
using Neptuo;
using Neptuo.Bootstrap;
using Neptuo.Commands;
using Neptuo.Data;
using Neptuo.Data.Entity;
using Neptuo.Lifetimes;
using Neptuo.Lifetimes.Mapping;
using Neptuo.TemplateEngine.Accounts.Data.Entity;
using Neptuo.TemplateEngine.Web.Controllers;
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
using TemplateEngine.Data.Entity;

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
        }

        protected void RegisterBootstrapTasks(IBootstrapTaskRegistry bootstrapper, IDependencyContainer container)
        {
            bootstrapper.Register<ViewServiceBootstrapTask>();
            bootstrapper.Register<RoutingBootstrapTask>();
            bootstrapper.Register<NavigationBootstrapTask>();
            bootstrapper.Register<PresentationModelBootstrapTask>();
            bootstrapper.Register<BindingBootstrapTask>();

            bootstrapper.Register<AccountBootstrapTask>();
        }

        protected virtual IDependencyContainer CreateDependencyContainer()
        {
            UnityDependencyContainer dependencyContainer = new UnityDependencyContainer();
            dependencyContainer.Map(typeof(SingletonLifetime), new SingletonLifetimeMapper());
            dependencyContainer.Map(typeof(GetterLifetime), new GetterLifetimeMapper());
            dependencyContainer.Map(typeof(PerRequestLifetime), new PerRequestLifetimeMapper());

            DataContext dataContext = new DataContext();

            dependencyContainer
                .RegisterType<HttpContextBase>(new GetterLifetime(() => new HttpContextWrapper(HttpContext.Current)))
                .RegisterType<DataContext>(new PerRequestLifetime())
                .RegisterType<IUnitOfWorkFactory, DataContextUnitOfWorkFactory>(new PerRequestLifetime())
                .RegisterType<IAccountDbContext, DataContext>(new PerRequestLifetime())
                .RegisterType<ICommandDispatcher, DependencyCommandDispatcher>()
                .RegisterType<IControllerRegistry>(new SingletonLifetime(new ControllerRegistryBase()))
                .RegisterInstance<IDependencyProvider>(dependencyContainer)
                .RegisterInstance<IDependencyContainer>(dependencyContainer);

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

        }

        //protected void Session_End(object sender, EventArgs e)
        //{

        //}

        //protected void Application_End(object sender, EventArgs e)
        //{

        //}
    }
}
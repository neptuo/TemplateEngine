using Microsoft.Practices.Unity;
using Neptuo;
using Neptuo.Bootstrap;
using Neptuo.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

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
        }

        protected virtual IDependencyContainer CreateDependencyContainer()
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer
                .RegisterType<HttpContextBase>(new GetterLifetimeManager(() => new HttpContextWrapper(HttpContext.Current)));

            UnityDependencyContainer dependencyContainer = new UnityDependencyContainer(unityContainer);
            dependencyContainer
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

        //protected void Application_Error(object sender, EventArgs e)
        //{

        //}

        //protected void Session_End(object sender, EventArgs e)
        //{

        //}

        //protected void Application_End(object sender, EventArgs e)
        //{

        //}
    }
}
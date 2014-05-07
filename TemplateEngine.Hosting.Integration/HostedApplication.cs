using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using log4net;
using log4net.Config;
using Neptuo.Bootstrap;
using Neptuo.Events;
using Neptuo.Lifetimes;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Hosting.DataSources;
using Neptuo.TemplateEngine.Hosting.Integration.Bootstrap;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Security;
using Neptuo.Templates.Compilation;
using Neptuo.Unity;
using Neptuo.Unity.Lifetimes.Mapping;
using Neptuo.Unity.Web.Lifetimes.Mapping;
using Neptuo.Validation;
using Neptuo.Web;
using Neptuo.TemplateEngine.Navigation.Bootstrap;

namespace Neptuo.TemplateEngine.Hosting.Integration
{
    public class HostedApplication : HttpApplication
    {
        private IApplicationBuilder builder;

        public static IApplicationBuilder Empty
        {
            get { return new ApplicationBuilderBase(); }
        }

        public HostedApplication(IApplicationBuilder builder)
        {
            Guard.NotNull(builder, "builder");
            this.builder = builder;
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            IDependencyContainer container = CreateDependencyContainer();
            ManualBootstrapper bootstrapper = CreateBootstrapper(container);

            RegisterBootstrapTasks(bootstrapper, container);
            bootstrapper.Initialize();

            Converts.Repository.Add(typeof(string), typeof(int), new StringToIntConverter());
            XmlConfigurator.Configure();

            builder.RegisterForms(container.Resolve<IFormUriRegistry>(), container.Resolve<ITemplateUrlFormatter>());
            builder.RegisterGlobalNavigations(container.Resolve<GlobalNavigationCollection>());

            OnAfterStart();
        }

        protected virtual void OnAfterStart()
        { }

        protected void RegisterBootstrapTasks(IBootstrapTaskRegistry bootstrapper, IDependencyContainer container)
        {
            bootstrapper.Register<ViewServiceBootstrapTask>();
            bootstrapper.Register<RoutingBootstrapTask>();
            bootstrapper.Register<NavigationBootstrapTask>();
            bootstrapper.Register<PresentationModelBootstrapTask>();
            bootstrapper.Register<BindingBootstrapTask>();
            bootstrapper.Register<ConfigurationBootstrapTask>();
            bootstrapper.Register<ConverterBootstrapTask>();
            bootstrapper.Register<AuthenticationBootstrapTask>();

            builder.RegisterBootstrapTasks(bootstrapper);
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
                .RegisterInstance<IGuidProvider>(new GuidProvider())
                .RegisterType<IValidatorService, DependencyValidatorService>()
                .RegisterType<IParameterProvider, RequestParameterProvider>(new PerRequestLifetime())
                .RegisterType<IControllerRegistry>(new SingletonLifetime(new ControllerRegistryBase()))
                .RegisterType<IPermissionProvider, OptimisticPermissionProvider>(new PerRequestLifetime())
                .RegisterInstance<IWebDataSourceRegistry>(new DictionaryWebDataSourceRegistry())
                .RegisterInstance<ITemplateUrlFormatter>(new TemplateUrlFomatter())
                .RegisterType<IUserContext, AnonymousUserContext>();

            builder.RegisterTypes(dependencyContainer);

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
            Exception exception = Server.GetLastError();
            CodeDomViewServiceException viewServiceException = exception as CodeDomViewServiceException;
            if (viewServiceException != null)
            {
                StringBuilder message = new StringBuilder();
                message.AppendLine(exception.Message);

                foreach (IErrorInfo errorInfo in viewServiceException.Errors)
                {
                    message.AppendFormat(
                        "Line: {0}, Column: {1}, Error no.: {2}, Text: {3}",
                        errorInfo.Line,
                        errorInfo.Column,
                        errorInfo.ErrorNumber,
                        errorInfo.ErrorText
                    );
                    message.AppendLine();
                }

                LogManager.GetLogger("Global").Fatal(message);
            }
            else
            {
                LogManager.GetLogger("Global").Fatal(null, exception);
            }
        }

        //protected void Session_End(object sender, EventArgs e)
        //{

        //}

        //protected void Application_End(object sender, EventArgs e)
        //{

        //}
    }
}

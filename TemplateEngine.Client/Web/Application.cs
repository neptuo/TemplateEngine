using Neptuo.Bootstrap;
using Neptuo.Bootstrap.Constraints;
using Neptuo.Client.Compilation;
using Neptuo.Lifetimes;
using Neptuo.ObjectBuilder;
using Neptuo.ObjectBuilder.Lifetimes.Mapping;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Permissions;
using Neptuo.TemplateEngine.PresentationModels;
using Neptuo.TemplateEngine.Web.Controllers;
using Neptuo.Templates;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class Application : IApplication, IVirtualUrlProvider
    {
        public static IApplication Instance { get; private set; }

        public string ApplicationPath { get; private set; }
        public string[] DefaultToUpdate { get; private set; }
        public IHistoryState HistoryState { get; private set; }
        public IDependencyContainer DependencyContainer { get; private set; }

        public static void Start(string applicationPath, string[] defaultToUpdate)
        {
            if (Instance != null)
                throw new ApplicationException("Application is already started."); //TODO: Ehm, be quiet?

            Instance = new Application(applicationPath, defaultToUpdate);
        }

        public string ResolveUrl(string path)
        {
            return path.Replace("~/", ApplicationPath);
        }

        private Application(string applicationPath, string[] defaultToUpdate)
        {
            Guard.NotNull(applicationPath, "applicationPath");
            Guard.NotNull(defaultToUpdate, "defaultToUpdate");

            DependencyContainer = CreateDependencyContainer();
            ApplicationPath = applicationPath;
            DefaultToUpdate = defaultToUpdate;

            HistoryState.OnPop += OnHistoryStatePop;



            // At last...
            RunBootstrapTasks(DependencyContainer);
        }

        private IDependencyContainer CreateDependencyContainer()
        {
            DependencyContainer container = new DependencyContainer();
            container
                .Map(typeof(SingletonLifetime), new SingletonLifetimeMapper());

            DefaultFormUriService formService = new DefaultFormUriService();
            FormUriServiceRegistration.SetInstance(formService);

            HistoryState = new HistoryState();

            container
                .RegisterType<IStackStorage<IViewStorage>, StackStorage<IViewStorage>>()
                .RegisterType<IVirtualUrlProvider, UrlProvider>()
                .RegisterType<ICurrentUrlProvider, UrlProvider>()
                .RegisterType<IParameterProviderFactory, ParameterProviderFactory>()
                .RegisterType<IParameterProvider, AllParameterProvider>()
                .RegisterType<IBindingManager, BindingManagerBase>()
                .RegisterType<IValueConverterService, ValueConverterService>()
                .RegisterType<IRequestContext, CompositeRequestContext>()
                .RegisterInstance(new TemplateContentStorageStack())
                .RegisterInstance(new DataContextStorage())
                .RegisterInstance<IGuidProvider>(new SequenceGuidProvider("guid", 1))
                .RegisterType<IViewActivator, StaticViewActivator>(new SingletonLifetime())

                .RegisterInstance(new GlobalNavigationCollection())

                .RegisterInstance<IFormUriService>(formService)
                .RegisterInstance<IFormUriRegistry>(formService)

                .RegisterInstance<IControllerRegistry>(new ControllerRegistryBase())
                .RegisterInstance<IPermissionProvider>(new OptimisticPermissionProvider())

                .RegisterInstance<IHistoryState>(HistoryState);

            return container;
        }

        private void RunBootstrapTasks(IDependencyContainer dependencyContainer)
        {
            Func<Type, IBootstrapTask> taskFactory = (type) => dependencyContainer.Resolve(type, null).As<IBootstrapTask>();
            Func<Type, IBootstrapConstraint> constrainFactory = (type) => dependencyContainer.Resolve(type, null).As<IBootstrapConstraint>();

            IBootstrapper bootstrapper = new AutomaticBootstrapper(taskFactory, JsCompiler.NewTypes.As<JsArray<Type>>(), new AttributeConstraintProvider(constrainFactory));
            bootstrapper.Initialize();
        }

        private void OnHistoryStatePop(HistoryItem historyItem)
        {
            throw new NotImplementedException();
        }

    }
}

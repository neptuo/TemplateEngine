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
using Neptuo.TemplateEngine.Web.Controllers.Binders;
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
        public IMainView MainView { get; private set; }
        public IDependencyContainer DependencyContainer { get; private set; }
        public IFormPostInvokerManager FormPostInvokers { get; private set; }

        #region Initialization

        private Application(string applicationPath, string[] defaultToUpdate)
        {
            Guard.NotNull(applicationPath, "applicationPath");
            Guard.NotNull(defaultToUpdate, "defaultToUpdate");

            DependencyContainer = CreateDependencyContainer();
            ApplicationPath = applicationPath;
            DefaultToUpdate = defaultToUpdate;

            //TODO: Move
            Converts.Repository
                .Add(typeof(JsObject), typeof(PartialResponse), new PartialResponseConverter());

            //HistoryState.OnPop += OnHistoryStatePop;

            //MainView.OnLinkClick += OnNavigation;
            //MainView.OnGetFormSubmit += OnNavigation;
            //MainView.OnPostFormSubmit += OnFormSubmit;

            FormPostInvokers = new QueueFormPostInvokerManager();

            // At last...
            RunBootstrapTasks(DependencyContainer);
        }

        public static void Start(string applicationPath, string[] defaultToUpdate)
        {
            if (Instance != null)
                throw new ApplicationException("Application is already started."); //TODO: Ehm, be quiet?

            Instance = new Application(applicationPath, defaultToUpdate);
        }

        private IDependencyContainer CreateDependencyContainer()
        {
            DependencyContainer container = new DependencyContainer();
            container
                .Map(typeof(SingletonLifetime), new SingletonLifetimeMapper());

            DefaultFormUriService formService = new DefaultFormUriService();
            FormUriServiceRegistration.SetInstance(formService);

            IViewActivator viewActivator = new StaticViewActivator(container);

            HistoryState = new HistoryState();
            MainView = new MainView(viewActivator);

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
                .RegisterInstance<IViewActivator>(viewActivator)

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

        #endregion

        private void OnHistoryStatePop(HistoryItem historyItem)
        {
            //TODO: Invoke router
        }

        private void OnNavigation(string url, string[] toUpdate)
        {
            MainView.RenderView(url, toUpdate, DependencyContainer.CreateChildContainer());
        }

        private void OnFormSubmit(FormRequestContext context)
        {
            //TODO: Process POST
        }
        
        public bool TryInvokeControllers(Dictionary<string, string> parameters)
        {
            IDependencyContainer container = DependencyContainer.CreateChildContainer();
            container.RegisterInstance<IParameterProvider>(new DictionaryParameterProvider(parameters));

            IControllerRegistry controllerRegistry = container.Resolve<IControllerRegistry>();
            ViewDataCollection viewData = new ViewDataCollection();
            IModelBinder modelBinder = container.Resolve<IModelBinder>();
            NavigationCollection localNavigations = new NavigationCollection();
            bool isControllerExecuted = false;

            foreach (KeyValuePair<string, string> parameter in parameters)
            {
                string key = parameter.Key;
                IController controller;
                if (controllerRegistry.TryGet(key, out controller))
                {
                    controller.Execute(new ControllerContext(key, viewData, modelBinder, localNavigations));
                    isControllerExecuted = true;
                }
            }

            //TODO: Process navigations

            return isControllerExecuted;
        }

        private void NavigateToUrl(string url, string[] toUpdate)
        {
            //TODO: Invoke router...
        }

        #region Url provider

        public string ResolveUrl(string path)
        {
            return path.Replace("~/", ApplicationPath);
        }

        #endregion

    }
}

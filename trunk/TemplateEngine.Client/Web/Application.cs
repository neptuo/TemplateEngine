using Neptuo.Bootstrap;
using Neptuo.Bootstrap.Constraints;
using Neptuo.Client.Compilation;
using Neptuo.Lifetimes;
using Neptuo.ObjectBuilder;
using Neptuo.ObjectBuilder.Lifetimes.Mapping;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Routing;
using Neptuo.TemplateEngine.Templates;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using Neptuo.Templates;
using SharpKit.JavaScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Providers;

namespace Neptuo.TemplateEngine.Web
{
    /// <summary>
    /// Actual implmentation of <see cref="IApplication"/>.
    /// Entry point is static method <see cref="Start"/>.
    /// </summary>
    public class Application : IApplication, IVirtualUrlProvider, ICurrentUrlProvider, ITemplateUrlFormatter
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static IApplication Instance { get; private set; }

        /// <summary>
        /// Contains debug flag.
        /// </summary>
        public bool IsDebug { get; private set; }

        /// <summary>
        /// Application relative path.
        /// Eg. /AppRootDirectory.
        /// </summary>
        public string ApplicationPath { get; private set; }
        
        /// <summary>
        /// Default list of regions to update when not defined.
        /// </summary>
        public string[] DefaultToUpdate { get; private set; }

        /// <summary>
        /// Url suffix for templates.
        /// </summary>
        public string TemplateUrlSuffix { get; private set; }

        public IHistoryState HistoryState { get; private set; }
        public IMainView MainView { get; private set; }
        public IDependencyContainer DependencyContainer { get; private set; }
        public IControllerInvokeManager ControllerManager { get; private set; }
        public IRouter Router { get; private set; }
        public IUpdateViewNotifier UpdateViewNotifier { get; private set; }
        public IAsyncControllerRegistry ControllerRegistry { get; private set; }

        #region Initialization

        private Application(bool isDebug, string applicationPath, string[] defaultToUpdate, string templateUrlSuffix)
        {
            Guard.NotNull(applicationPath, "applicationPath");
            Guard.NotNull(defaultToUpdate, "defaultToUpdate");
            Guard.NotNull(templateUrlSuffix, "templateUrlSuffix");

            IsDebug = isDebug;
            ApplicationPath = applicationPath;
            DefaultToUpdate = defaultToUpdate;
            TemplateUrlSuffix = templateUrlSuffix;

            DependencyContainer = CreateDependencyContainer();

            HistoryState.OnPop += OnHistoryStatePop;

            MainView.OnLinkClick += OnNavigation;
            MainView.OnGetFormSubmit += OnNavigation;
            MainView.OnPostFormSubmit += OnFormSubmit;

            // At last...
            RunBootstrapTasks(DependencyContainer);
        }

        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="isDebug">Contains debug flag.</param>
        /// <param name="applicationPath">Application relative path.</param>
        /// <param name="defaultToUpdate">Default list of regions to update when not defined.</param>
        /// <param name="templateUrlSuffix">Url suffix for templates.</param>
        public static void Start(bool isDebug, string applicationPath, string[] defaultToUpdate, string templateUrlSuffix)
        {
            if (Instance != null)
                throw new ApplicationException("Application is already started."); //TODO: Ehm, be quiet?

            Instance = new Application(isDebug, applicationPath, defaultToUpdate, templateUrlSuffix);
        }

        /// <summary>
        /// Creates and register root dependency container.
        /// </summary>
        private IDependencyContainer CreateDependencyContainer()
        {
            DependencyContainer container = new DependencyContainer();
            container
                .Map(typeof(SingletonLifetime), new SingletonLifetimeMapper());

            IViewActivator viewActivator = new StaticViewActivator(container);

            HistoryState = new HistoryState();
            MainView = new MainView(viewActivator, this);

            Router = new ApplicationRouter(!IsDebug);
            Router.AddRoute(new StaticTemplateRoute("/", "~/Default" + TemplateUrlSuffix, TemplateUrlSuffix, this));
            Router.AddRoute(new TemplateRoute(TemplateUrlSuffix, this));

            UpdateViewNotifier = new UpdateViewNotifier(MainView);
            ControllerManager = new QueueControllerInvokeManager();
            ControllerRegistry = new AsyncControllerRegistryBase();

            container
                .RegisterInstance<IVirtualUrlProvider>(this)
                .RegisterInstance<ICurrentUrlProvider>(this)
                .RegisterInstance<ITemplateUrlFormatter>(this)
                .RegisterType<IParameterProviderFactory, RouteParameterProviderFactory>()
                .RegisterType<IParameterProvider, RouteParameterProvider>()
                .RegisterType<IBindingManager, ClientBindingManager>()
                .RegisterType<IValueConverterService, ValueConverterService>()
                .RegisterType<IRequestContext, CompositeRequestContext>()
                .RegisterInstance(new TemplateContentStorageStack())
                .RegisterInstance(new DataContextStorage())
                .RegisterInstance<IGuidProvider>(new SequenceGuidProvider("guid", 1))
                .RegisterInstance<IViewActivator>(viewActivator)

                .RegisterInstance(new GlobalNavigationCollection())

                .RegisterInstance<IFormUriRepository>(FormUriTable.Repository)
                .RegisterInstance<IFormUriRegistry>(FormUriTable.Registry)

                .RegisterInstance<IAsyncControllerRegistry>(ControllerRegistry)

                .RegisterInstance<IHistoryState>(HistoryState)
                .RegisterInstance<IMainView>(MainView)
                
                .RegisterInstance<IRouter>(Router);

            return container;
        }

        /// <summary>
        /// Executes all loaded bootstrap tasks.
        /// </summary>
        private void RunBootstrapTasks(IDependencyContainer dependencyContainer)
        {
            Func<Type, IBootstrapTask> taskFactory = (type) => dependencyContainer.Resolve(type, null).As<IBootstrapTask>();
            Func<Type, IBootstrapConstraint> constrainFactory = (type) => dependencyContainer.Resolve(type, null).As<IBootstrapConstraint>();

            IBootstrapper bootstrapper = new AutomaticBootstrapper(taskFactory, JsCompiler.NewTypes.As<JsArray<Type>>(), new AttributeConstraintProvider(constrainFactory));
            bootstrapper.Initialize();

            JsCompiler.AfterNextCompilation(AfterCompilation);
        }

        private void AfterCompilation()
        {
            RunBootstrapTasks(DependencyContainer);
        }

        #endregion

        /// <summary>
        /// When history state is changed.
        /// </summary>
        private void OnHistoryStatePop(HistoryItem historyItem)
        {
            if (historyItem == null)
                historyItem = new HistoryItem(GetCurrentUrl(), DefaultToUpdate);

            Router.RouteTo(
                new RequestContext(
                    historyItem.Url,
                    historyItem.FormData.ToRouteParams(),
                    new RouteValueDictionary()
                        .AddItem("ToUpdate", historyItem.ToUpdate)
                )
            );
        }

        /// <summary>
        /// When user invokes navigation.
        /// </summary>
        /// <param name="url">New url.</param>
        /// <param name="toUpdate">List regions to update.</param>
        private void OnNavigation(string url, string[] toUpdate)
        {
            UpdateViewNotifier.StartUpdate();
            toUpdate = toUpdate ?? DefaultToUpdate;

            HistoryState.Push(new HistoryItem(url, toUpdate));
            NavigateToUrl(url, toUpdate);
        }

        /// <summary>
        /// When user submits post form.
        /// </summary>
        /// <param name="context"></param>
        private void OnFormSubmit(FormRequestContext context)
        {
            InvokeController(context);
        }
        
        /// <summary>
        /// Invokes controllers.
        /// </summary>
        /// <param name="context">Request context.</param>
        public void InvokeController(FormRequestContext context)
        {
            UpdateViewNotifier.StartUpdate();
            ControllerManager.Invoke(new ControllerInvoker(this, ControllerRegistry, context));
        }

        /// <summary>
        /// Renders <paramref name="url"/>.
        /// </summary>
        /// <param name="url">New url.</param>
        /// <param name="toUpdate">List regions to update.</param>
        private void NavigateToUrl(string url, string[] toUpdate)
        {
            Router.RouteTo(new RequestContext(url, new RouteParamDictionary(), new RouteValueDictionary().AddItem("ToUpdate", toUpdate)));
        }

        #region Url

        public string ResolveUrl(string path)
        {
            string applicationPath = ApplicationPath;
            if (!ApplicationPath.EndsWith("/"))
                applicationPath += "/";

            return path.Replace("~/", applicationPath);
        }

        public string GetCurrentUrl()
        {
            return SharpKit.Html.HtmlContext.location.pathname;
        }

        public string FormatUrl(string urlPart)
        {
            return urlPart + TemplateUrlSuffix;
        }

        #endregion
    }
}

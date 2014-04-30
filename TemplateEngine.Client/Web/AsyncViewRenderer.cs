using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Templates;
using Neptuo.Templates;
using SharpKit.JavaScript;
using SharpKit.jQuery;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class AsyncViewRenderer : IAsyncViewRenderer
    {
        public string ViewPath { get; private set; }
        public string[] ToUpdate { get; private set; }
        public IDependencyContainer DependencyContainer { get; private set; }
        public IViewActivator ViewActivator { get; private set; }
        public IViewLoadedChecker Checker { get; private set; }
        public IVirtualUrlProvider UrlProvider { get; private set; }

        public event Action OnCompleted;

        private BaseGeneratedView view;
        private AsyncNotifyService notifyService;
        private bool isNotifyReadyCalled;

        public AsyncViewRenderer(string viewPath, string[] toUpdate, IDependencyContainer dependencyContainer, IViewActivator viewActivator, IViewLoadedChecker checker, IVirtualUrlProvider urlProvider)
        {
            Guard.NotNullOrEmpty(viewPath, "viewPath");
            Guard.NotNull(toUpdate, "toUpdate");
            Guard.NotNull(dependencyContainer, "dependencyContainer");
            Guard.NotNull(viewActivator, "viewActivator");
            Guard.NotNull(checker, "checker");
            Guard.NotNull(urlProvider, "urlProvider");
            ViewPath = viewPath;
            ToUpdate = toUpdate;
            DependencyContainer = dependencyContainer;
            ViewActivator = viewActivator;
            Checker = checker;
            UrlProvider = urlProvider;
        }

        public void Render()
        {
            if (!Checker.IsViewLoaded(ViewPath))
            {
                jQuery.ajax(new AjaxSettings
                {
                    url = FormatViewUrl(),
                    dataType = "script",
                    success = OnScriptLoaded
                });
            }
            else
            {
                RenderView();
            }
        }

        private void OnScriptLoaded(object data, JsString status, jqXHR response)
        {
            RenderView();
        }

        private string FormatViewUrl()
        {
            string viewPath = ViewPath;
            if (viewPath.StartsWith("/"))
                viewPath = "~" + viewPath;

            return String.Format("{0}?Path={1}", UrlProvider.ResolveUrl("~/Views.ashx"), viewPath);
        }

        private void RenderView()
        {
            notifyService = new AsyncNotifyService();
            PartialUpdateComponentManager componentManager = new PartialUpdateComponentManager(ToUpdate);
            DependencyContainer
                .RegisterInstance<IComponentManager>(componentManager)
                .RegisterInstance<IPartialUpdateWriter>(componentManager)
                .RegisterInstance<AsyncNotifyService>(notifyService);

            view = ViewActivator.CreateView(ViewPath);
            view.Setup(new BaseViewPage(componentManager), componentManager, DependencyContainer);
            view.CreateControls();
            view.Init();

            if (notifyService.IsReady)
                OnAsyncNotifyReady();
            else
                notifyService.OnReady += OnAsyncNotifyReady;
        }

        private void OnAsyncNotifyReady()
        {
            if (isNotifyReadyCalled)
                SharpKit.Html.HtmlContext.alert("OnReady called twice!!");

            isNotifyReadyCalled = true;

            notifyService.OnReady -= OnAsyncNotifyReady;

            StringWriter writer = new StringWriter();
            view.Render(new ExtendedHtmlTextWriter(writer));
            view.Dispose();

            if (OnCompleted != null)
                OnCompleted();
        }
    }
}

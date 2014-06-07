using Neptuo.TemplateEngine.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    /// <summary>
    /// Route handler for rendering template.
    /// </summary>
    public class TemplateRouteHandler : IRouteHandler
    {
        /// <summary>
        /// Main view.
        /// </summary>
        public IMainView MainView { get; private set; }

        /// <summary>
        /// View path to render.
        /// </summary>
        public string ViewPath { get; private set; }

        /// <summary>
        /// List regions to update.
        /// </summary>
        public string[] ToUpdate { get; private set; }

        /// <summary>
        /// Container for rendering view.
        /// </summary>
        public IDependencyContainer DependencyContainer { get; private set; }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="mainView">Main view.</param>
        /// <param name="viewPath">View path to render.</param>
        /// <param name="toUpdate">List regions to update.</param>
        /// <param name="dependencyContainer">Container for rendering view.</param>
        public TemplateRouteHandler(IMainView mainView, string viewPath, string[] toUpdate, IDependencyContainer dependencyContainer)
        {
            Guard.NotNull(mainView, "mainView");
            Guard.NotNullOrEmpty(viewPath, "viewPath");
            Guard.NotNull(toUpdate, "toUpdate");
            Guard.NotNull(dependencyContainer, "dependencyContainer");
            MainView = mainView;
            ViewPath = viewPath;
            ToUpdate = toUpdate;
            DependencyContainer = dependencyContainer;
        }

        /// <summary>
        /// Renders view.
        /// </summary>
        /// <param name="context">Route context.</param>
        public void ProcessRequest(RouteContext context)
        {
            DependencyContainer.RegisterInstance(context);
            MainView.RenderView(ViewPath, ToUpdate, DependencyContainer);
        }
    }
}

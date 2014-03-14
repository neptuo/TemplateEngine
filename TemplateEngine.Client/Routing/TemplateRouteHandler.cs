using Neptuo.TemplateEngine.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public class TemplateRouteHandler : IRouteHandler
    {
        public IMainView MainView { get; private set; }
        public string ViewPath { get; private set; }
        public string[] ToUpdate { get; private set; }
        public IDependencyContainer DependencyContainer { get; private set; }

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

        public void ProcessRequest(RouteContext context)
        {
            DependencyContainer.RegisterInstance(context);
            MainView.RenderView(ViewPath, ToUpdate, DependencyContainer);
        }
    }
}

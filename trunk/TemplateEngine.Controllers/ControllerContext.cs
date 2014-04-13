using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public class ControllerContext : IControllerContext
    {
        public string ActionName { get; private set; }
        public IViewData ViewData { get; private set; }
        public IModelBinder ModelBinder { get; private set; }
        public NavigationCollection Navigations { get; private set; }

        public ControllerContext(string action, IViewData viewData, IModelBinder modelBinder, NavigationCollection navigations)
        {
            Guard.NotNull(action, "action");
            Guard.NotNull(viewData, "viewData");
            Guard.NotNull(modelBinder, "modelBinder");
            Guard.NotNull(navigations, "navigations");

            ActionName = action;
            ViewData = viewData;
            ModelBinder = modelBinder;
            Navigations = navigations;
        }
    }
}

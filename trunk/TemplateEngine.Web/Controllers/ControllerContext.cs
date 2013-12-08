using Neptuo.TemplateEngine.Web.Controllers.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    public class ControllerContext : IControllerContext
    {
        public string Action { get; private set; }
        public IViewData ViewData { get; private set; }
        public IModelBinder ModelBinder { get; private set; }
        public NavigationCollection Navigations { get; private set; }

        public ControllerContext(string action, IViewData viewData, IModelBinder modelBinder, NavigationCollection navigations)
        {
            Action = action;
            ViewData = viewData;
            ModelBinder = modelBinder;
            Navigations = navigations;
        }
    }
}

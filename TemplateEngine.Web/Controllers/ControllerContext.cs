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
        public IViewData ViewData { get; private set; }
        public IModelBinder ModelBinder { get; private set; }

        public ControllerContext(IViewData viewData, IModelBinder modelBinder)
        {
            ViewData = viewData;
            ModelBinder = modelBinder;
        }
    }
}

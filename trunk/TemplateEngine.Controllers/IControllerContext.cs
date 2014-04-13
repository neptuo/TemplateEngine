using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public interface IControllerContext
    {
        string ActionName { get; }
        IViewData ViewData { get; }
        IModelBinder ModelBinder { get; }
        NavigationCollection Navigations { get; }
    }

}

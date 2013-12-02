using Neptuo.TemplateEngine.Web.Controllers.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    public interface IControllerContext
    {
        IViewData ViewData { get; }
        IModelBinder ModelBinder { get; }
    }

}

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
        IModelBinder ModelBinder { get; }
        IDependencyProvider DependencyProvider { get; }
        NavigationCollection Navigations { get; }
        MessageStorage Messages { get; }
    }

}

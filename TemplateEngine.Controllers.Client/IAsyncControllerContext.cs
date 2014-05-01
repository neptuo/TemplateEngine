using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Providers.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public interface IAsyncControllerContext
    {
        string ActionName { get; }
        IParameterProvider Parameters { get; }
        IModelBinder ModelBinder { get; }
        IDependencyProvider DependencyProvider { get; }
        
        string Navigation { get; set; }
        MessageStorage Messages { get; }

        void OnComplete();
    }
}

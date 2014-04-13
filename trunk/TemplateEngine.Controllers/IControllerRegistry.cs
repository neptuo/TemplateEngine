using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public interface IControllerRegistry
    {
        IControllerRegistry Add(string actionName, IControllerFactory factory);
        IControllerRegistry Add(string actionName, IAsyncControllerFactory factory);

        bool TryGet(string actionName, out IController controller);
        bool TryGetAsync(string actionName, out IAsyncController controller);
    }
}

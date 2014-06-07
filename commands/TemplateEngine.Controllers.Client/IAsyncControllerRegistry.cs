using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public interface IAsyncControllerRegistry
    {
        IAsyncControllerRegistry Add(string actionName, IAsyncControllerFactory factory);

        bool TryGet(string actionName, out IAsyncController controller);
    }
}

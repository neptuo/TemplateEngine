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

        bool TryGet(string actionName, out IController controller);
    }
}

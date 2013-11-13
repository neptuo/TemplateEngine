using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    public interface IControllerRegistry
    {
        IControllerRegistry Add(string eventName, IControllerFactory factory);

        bool TryGet(string eventName, out IController handler);
    }
}

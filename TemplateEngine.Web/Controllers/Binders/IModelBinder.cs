using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers.Binders
{
    public interface IModelBinder
    {
        object Bind(Type targetType);
        object Bind(object instance);
    }
}

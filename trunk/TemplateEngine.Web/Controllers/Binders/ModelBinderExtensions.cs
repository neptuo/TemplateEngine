using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers.Binders
{
    public static class ModelBinderExtensions
    {
        public static T Bind<T>(this IModelBinder binder)
        {
            return (T)binder.Bind(typeof(T));
        }

        public static T Bind<T>(this IModelBinder binder, T instance)
        {
            return (T)binder.Bind(instance);
        }
    }
}

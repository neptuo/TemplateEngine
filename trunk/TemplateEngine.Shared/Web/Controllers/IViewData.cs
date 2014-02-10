using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    public interface IViewData
    {
        object Get(string key);
        void Set(string key, object data);
    }

    public static class ViewDataExtensions
    {
        public static T Get<T>(this IViewData viewData, string key)
        {
            object data = viewData.Get(key);
            if (data is T)
                return (T)data;

            return default(T);
        }
    }
}

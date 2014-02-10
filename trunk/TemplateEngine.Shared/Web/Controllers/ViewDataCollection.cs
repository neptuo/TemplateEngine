using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    public class ViewDataCollection : IViewData
    {
        public Dictionary<string, object> Data { get; private set; }

        public ViewDataCollection()
        {
            Data = new Dictionary<string, object>();
        }

        public object Get(string key)
        {
            if (key == null)
                return null;

            if (Data.ContainsKey(key))
                return Data[key];

            return null;
        }

        public void Set(string key, object data)
        {
            Guard.NotNull(key, "key");
            Data[key] = data;
        }
    }
}
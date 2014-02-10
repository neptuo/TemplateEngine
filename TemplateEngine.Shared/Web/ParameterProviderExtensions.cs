using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public static class ParameterProviderExtensions
    {
        public static Dictionary<string, object> GetAllParameters(this IParameterProvider provider)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            object value;
            foreach (string key in provider.Keys)
            {
                if (provider.TryGet(key, out value))
                    result[key] = value;
            }
            return result;
        }
    }
}

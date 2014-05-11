using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    /// <summary>
    /// Custom route value dictionary.
    /// </summary>
    public class RouteValueDictionary : Dictionary<string, object>
    {
        public RouteValueDictionary AddItem(string key, object value)
        {
            Add(key, value);
            return this;
        }
    }
}

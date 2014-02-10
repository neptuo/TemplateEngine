using Neptuo.TemplateEngine.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class GlobalNavigationCollection
    {
        private Dictionary<string, FormUri> storage = new Dictionary<string, FormUri>();

        public GlobalNavigationCollection Add(string name, FormUri to)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (to == null)
                throw new ArgumentNullException("to");

            storage[name] = to;
            return this;
        }

        public bool TryGetValue(string name, out FormUri to)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            return storage.TryGetValue(name, out to);
        }
    }
}

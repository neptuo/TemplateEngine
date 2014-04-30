using Neptuo.TemplateEngine.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    public class GlobalNavigationCollection
    {
        private Dictionary<string, FormUri> storage = new Dictionary<string, FormUri>();

        public GlobalNavigationCollection Add(string on, FormUri to)
        {
            if (on == null)
                throw new ArgumentNullException("name");

            if (to == null)
                throw new ArgumentNullException("to");

            storage[on] = to;
            return this;
        }

        public bool TryGetValue(string on, out FormUri to)
        {
            if (on == null)
            {
                to = null;
                return false;
            }

            return storage.TryGetValue(on, out to);
        }
    }
}

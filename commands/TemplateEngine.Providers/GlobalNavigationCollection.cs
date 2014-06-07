using Neptuo.TemplateEngine.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    /// <summary>
    /// Collectio of globally registered navigation rules.
    /// </summary>
    public class GlobalNavigationCollection
    {
        private Dictionary<string, FormUri> storage = new Dictionary<string, FormUri>();

        /// <summary>
        /// Adds nagivation rule.
        /// </summary>
        /// <param name="on">Navigation rule.</param>
        /// <param name="to">Target form.</param>
        /// <returns>This (fluently).</returns>
        public GlobalNavigationCollection Add(string on, FormUri to)
        {
            if (on == null)
                throw new ArgumentNullException("name");

            if (to == null)
                throw new ArgumentNullException("to");

            storage[on] = to;
            return this;
        }

        /// <summary>
        /// Tries get registered form for <paramref name="on"/>.
        /// </summary>
        /// <param name="on">Navigation rule.</param>
        /// <param name="to">Target form.</param>
        /// <returns>True is there is registered form for <paramref name="on"/>.</returns>
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

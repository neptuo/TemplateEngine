using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    public class NavigationCollection : IEnumerable<string>
    {
        private HashSet<string> items = new HashSet<string>();

        public void Add(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            items.Add(name);
        }

        public bool Contains(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            return items.Contains(name);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}

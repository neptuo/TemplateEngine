using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class CssClassCollection : IEnumerable<string>
    {
        private HashSet<string> storage = new HashSet<string>();

        public void Add(string className)
        {
            storage.Add(className);
        }

        public bool ContainsKey(string className)
        {
            return storage.Contains(className);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return storage.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return storage.GetEnumerator();
        }

        public override string ToString()
        {
            IEnumerable<string> values = storage;
            return String.Join(" ", values);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class DataContextStorage
    {
        private Dictionary<string, StackStorage<object>> storage = new Dictionary<string, StackStorage<object>>();

        public void Push(object value, string name = null)
        {
            if (name == null)
                name = String.Empty;

            StackStorage<object> stack;
            if(!storage.TryGetValue(name, out stack))
            {
                stack = new StackStorage<object>();
                storage[name] = stack;
            }

            stack.Push(value);
        }

        public object Pop(string name = null)
        {
            if (name == null)
                name = String.Empty;

            StackStorage<object> stack;
            if (storage.TryGetValue(name, out stack))
                return stack.Pop();

            return null;
        }

        public object Peek(string name = null)
        {
            if (name == null)
                name = String.Empty;

            StackStorage<object> stack;
            if (storage.TryGetValue(name, out stack))
                return stack.Peek();

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    /// <summary>
    /// Represents current context.
    /// Other objects can push data object into and another objects can acces them.
    /// Works in stack based fashion.
    /// Can contain multiple (named) stacks of data object.
    /// </summary>
    public class DataContextStorage
    {
        private Dictionary<string, StackStorage<object>> storage = new Dictionary<string, StackStorage<object>>();

        /// <summary>
        /// Pushes new object into (named) storage.
        /// </summary>
        /// <param name="value">New value.</param>
        /// <param name="name">Optional stack name.</param>
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

        /// <summary>
        /// Gets nad removes top value from (named) storage.
        /// </summary>
        /// <param name="name">Optional stack name.</param>
        public object Pop(string name = null)
        {
            if (name == null)
                name = String.Empty;

            StackStorage<object> stack;
            if (storage.TryGetValue(name, out stack))
                return stack.Pop();

            return null;
        }

        /// <summary>
        /// Gets top value from (named) storage, without removing it.
        /// </summary>
        /// <param name="name">Optional stack name.</param>
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

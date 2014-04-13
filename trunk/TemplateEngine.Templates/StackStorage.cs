using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine
{
    public class StackStorage<T> : IStackStorage<T>
    {
        protected Stack<T> Stack { get; private set; }

        public StackStorage()
        {
            Stack = new Stack<T>();
        }

        public void Push(T storage)
        {
            Stack.Push(storage);
        }

        public T Pop()
        {
            return Stack.Pop();
        }

        public T Peek()
        {
            return Stack.Peek();
        }
    }
}

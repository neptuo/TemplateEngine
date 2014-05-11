using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine
{
    /// <summary>
    /// Represents stack.
    /// </summary>
    /// <typeparam name="T">Item type.</typeparam>
    public interface IStackStorage<T>
    {
        /// <summary>
        /// Add new value.
        /// </summary>
        void Push(T storage);

        /// <summary>
        /// Gets and removes top value.
        /// </summary>
        T Pop();

        /// <summary>
        /// Gets top value, without removing it.
        /// </summary>
        T Peek();
    }
}

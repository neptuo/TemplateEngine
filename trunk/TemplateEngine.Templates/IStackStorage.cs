using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine
{
    public interface IStackStorage<T>
    {
        void Push(T storage);
        T Pop();
        T Peek();
    }
}

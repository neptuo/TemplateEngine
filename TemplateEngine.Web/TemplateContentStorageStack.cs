using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class TemplateContentStorageStack : IStackStorage<TemplateContentStorage>
    {
        private Stack<TemplateContentStorage> innerStorage = new Stack<TemplateContentStorage>();

        public TemplateContentStorage CreateStorage()
        {
            if (innerStorage.Any())
                return new TemplateContentStorage(innerStorage.Peek());

            return new TemplateContentStorage(null);
        }

        public void Push(TemplateContentStorage storage)
        {
            innerStorage.Push(storage);
        }

        public TemplateContentStorage Pop()
        {
            return innerStorage.Pop();
        }

        public TemplateContentStorage Peek()
        {
            return innerStorage.Peek();
        }
    }
}

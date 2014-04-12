using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    public interface IBindingManager
    {
        bool TrySetValue(object target, string expression, object value);
        bool TryGetValue(string expression, object source, out object value);
    }
}

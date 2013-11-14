using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public interface IBindingManager
    {
        void SetValue(object target, string expression, object value);
        object GetValue(string expression, object value);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public interface IParameterProvider
    {
        bool TryGet(string key, out object value);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Providers
{
    public interface IParameterProvider
    {
        IEnumerable<string> Keys { get; }

        bool TryGet(string key, out object value);
    }
}

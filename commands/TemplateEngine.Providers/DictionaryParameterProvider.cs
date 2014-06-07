using Neptuo.TemplateEngine.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class DictionaryParameterProvider : IParameterProvider
    {
        protected Dictionary<string, string> Parameters { get; private set; }

        public DictionaryParameterProvider(Dictionary<string, string> parameters)
        {
            Parameters = parameters;
        }

        public IEnumerable<string> Keys
        {
            get { return Parameters.Keys; }
        }

        public bool TryGet(string key, out object value)
        {
            string targetValue;
            if (Parameters.TryGetValue(key, out targetValue))
            {
                value = targetValue;
                return true;
            }

            value = null;
            return false;
        }
    }
}

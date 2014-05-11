using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.DataSources
{
    /// <summary>
    /// Actual implementation of <see cref="IWebDataSourceRegistry"/>
    /// </summary>
    public class DictionaryWebDataSourceRegistry : IWebDataSourceRegistry
    {
        protected Dictionary<string, Type> Registry { get; private set; }

        public DictionaryWebDataSourceRegistry()
        {
            Registry = new Dictionary<string, Type>();
        }

        public void Add(string name, Type dataSourceType)
        {
            Guard.NotNullOrEmpty(name, "name");
            Guard.NotNull(dataSourceType, "dataSourceType");
            Registry[name] = dataSourceType;
        }

        public bool TryGet(string name, out Type dataSourceType)
        {
            Guard.NotNullOrEmpty(name, "name");
            return Registry.TryGetValue(name, out dataSourceType);
        }
    }
}

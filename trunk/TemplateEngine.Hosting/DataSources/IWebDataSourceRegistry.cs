using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.DataSources
{
    /// <summary>
    /// Contains registration of web data sources.
    /// </summary>
    public interface IWebDataSourceRegistry
    {
        /// <summary>
        /// Adds datasource type to <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Data source name.</param>
        /// <param name="dataSourceType">Data source type.</param>
        void Add(string name, Type dataSourceType);

        /// <summary>
        /// Tries get data source type registered with <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Data source name.</param>
        /// <param name="dataSourceType">Data source type.</param>
        /// <returns>Trues if there is data source for <paramref name="name"/>.</returns>
        bool TryGet(string name, out Type dataSourceType);
    }
}

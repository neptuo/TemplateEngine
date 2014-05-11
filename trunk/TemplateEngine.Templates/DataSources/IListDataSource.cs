using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    /// <summary>
    /// Data source for list of items.
    /// </summary>
    public interface IListDataSource
    {
        /// <summary>
        /// Gets page of items.
        /// </summary>
        IEnumerable GetData(int? pageIndex, int? pageSize);

        /// <summary>
        /// Gets total items count.
        /// </summary>
        int GetTotalCount();
    }
}

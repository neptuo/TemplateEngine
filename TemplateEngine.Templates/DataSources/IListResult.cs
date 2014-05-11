using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    /// <summary>
    /// Describes result of <see cref="IListDataSource"/>.
    /// </summary>
    public interface IListResult
    {
        IEnumerable Data { get; }
        int TotalCount { get; }
    }
}

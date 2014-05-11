using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.DataSources
{
    /// <summary>
    /// Actual implementation of <see cref="IListResult"/>.
    /// </summary>
    public class ListResult : IListResult
    {
        public IEnumerable Data { get; private set; }
        public int TotalCount { get; private set; }

        public ListResult(IEnumerable data, int totalCount)
        {
            Data = data;
            TotalCount = totalCount;
        }
    }
}

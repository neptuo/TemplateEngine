using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.DataSources
{
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

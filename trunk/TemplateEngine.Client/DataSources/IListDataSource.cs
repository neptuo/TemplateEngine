using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.DataSources
{
    public interface IListDataSource
    {
        void GetData(int? pageIndex, int? pageSize, Action<IEnumerable> callback);
        int GetTotalCount();
    }
}

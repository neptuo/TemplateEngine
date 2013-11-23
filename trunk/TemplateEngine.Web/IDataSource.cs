using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public interface IListDataSource
    {
        IEnumerable GetData(int? pageIndex, int? pageSize);
        int GetTotalCount();
    }

    public interface IDataSource
    {
        object GetItem();
    }
}

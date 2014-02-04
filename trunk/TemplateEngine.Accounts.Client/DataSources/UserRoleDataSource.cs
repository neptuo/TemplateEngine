using Neptuo.TemplateEngine.Web.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    public class UserRoleDataSource : IListDataSource
    {
        public int? Key { get; set; }
        public string Name { get; set; }

        public int GetTotalCount()
        {
            return 0;
        }

        public void GetData(int? pageIndex, int? pageSize, Action<IListResult> callback)
        {
            callback(new ListResult(new List<object>(), 0));
        }
    }
}

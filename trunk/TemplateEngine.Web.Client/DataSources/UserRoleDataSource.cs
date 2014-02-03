using Neptuo.TemplateEngine.Web;
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

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            return new List<object>();
        }

        public int GetTotalCount()
        {
            return 0;
        }
    }
}

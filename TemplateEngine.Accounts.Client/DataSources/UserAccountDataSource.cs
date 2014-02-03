using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    public class UserAccountDataSource : IListDataSource, IDataSource
    {
        public int? Key { get; set; }
        public string Username { get; set; }

        public UserAccountDataSource()
        { }

        public object GetItem()
        {
            return null;
        }

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

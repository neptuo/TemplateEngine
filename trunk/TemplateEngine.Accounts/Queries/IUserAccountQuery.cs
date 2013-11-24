using Neptuo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Queries
{
    public interface IUserAccountQuery
    {
        UserAccount Get(Key key);
        IEnumerable<UserAccount> Get();
        IEnumerable<UserAccount> Get(int pageIndex, int pageSize);
    }
}

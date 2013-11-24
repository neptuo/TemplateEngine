using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Queries
{
    public interface IUserRoleQuery
    {
        IEnumerable<UserRole> Get();
        IEnumerable<UserRole> Get(int pageIndex, int pageSize);
    }
}

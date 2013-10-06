using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Queries
{
    public interface IUserQuery
    {
        IEnumerable<UserAccount> Get();
    }
}

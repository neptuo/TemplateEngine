using Neptuo.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Queries
{
    public interface IUserRoleFilter
    {
        IntSearch Key { get; set; }
        TextSearch Name { get; set; }
        TextSearch Description { get; set; }
    }
}

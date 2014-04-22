using Neptuo.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Queries
{
    public interface IResourcePermissionFilter
    {
        TextSearch ResourceName { get; set; }
        TextSearch PermissionName { get; set; }
        IntSearch RoleKey { get; set; }
    }
}

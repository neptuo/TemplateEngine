using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    public interface IResourcePermissionDataSourceFilter
    {
        int? RoleKey { get; set; }
        string ResourceName { get; set; }
        string PermissionName { get; set; }
    }
}
 
using Neptuo.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Queries
{
    public class ResourcePermissionFilter : IResourcePermissionFilter
    {
        public TextSearch ResourceName { get; set; }
        public TextSearch PermissionName { get; set; }
        public IntSearch RoleKey { get; set; }

        public ResourcePermissionFilter()
        { }

        public ResourcePermissionFilter(string resourceName, string permissionName, IEnumerable<int> roleKeys)
        {
            ResourceName = TextSearch.Create(resourceName);
            PermissionName = TextSearch.Create(permissionName);
            RoleKey = IntSearch.Create(roleKeys);
        }
    }
}

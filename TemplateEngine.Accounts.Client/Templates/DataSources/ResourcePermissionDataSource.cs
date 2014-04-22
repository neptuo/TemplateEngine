using Neptuo.TemplateEngine.Templates.DataSources;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    public class ResourcePermissionDataSource : DynamicListDataSourceProxy<ResourcePermissionListResult>
    {
        public int RoleKey { get; set; }

        public ResourcePermissionDataSource(IVirtualUrlProvider urlProvider)
            : base(urlProvider, GetFilterProperties())
        { }

        private static IEnumerable<string> GetFilterProperties()
        {
            return new List<string> { "RoleKey" };
        }
    }
}

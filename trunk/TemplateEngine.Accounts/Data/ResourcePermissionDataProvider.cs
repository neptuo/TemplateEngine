using Neptuo.TemplateEngine.Accounts.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data
{
    public class ResourcePermissionDataProvider : DataProviderBase<ResourcePermission, IResourcePermissionQuery, IResourcePermissionRepository>
    {
        public ResourcePermissionDataProvider(IResourcePermissionRepository repository, IActivator<IResourcePermissionQuery> queryFactory)
            : base(repository, queryFactory, repository)
        { }
    }
}

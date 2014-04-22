using Neptuo.Data.Queries;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class ResourcePermissionProvider : IPermissionProvider
    {
        private IEnumerable<int> roleKeys;
        private IActivator<IResourcePermissionQuery> queryFactory;

        public ResourcePermissionProvider(IActivator<IResourcePermissionQuery> queryFactory, IEnumerable<int> roleKeys)
        {
            Guard.NotNull(queryFactory, "queryFactory");
            Guard.NotNull(roleKeys, "roleKeys");
            this.queryFactory = queryFactory;
            this.roleKeys = roleKeys;
        }

        public bool IsAllowed(object key, string action)
        {
            var query = queryFactory.Create();
            query.Filter = new ResourcePermissionFilter(key.ToString(), action, roleKeys);
            return query.Any();
        }

        public IPermissionSet Get(object key)
        {
            var query = queryFactory.Create();
            query.Filter.ResourceName = TextSearch.Create(key.ToString());
            query.Filter.RoleKey = IntSearch.Create(roleKeys);
            return new PermissionSet(query.EnumerateItems(p => p.PermissionName));
        }
    }
}

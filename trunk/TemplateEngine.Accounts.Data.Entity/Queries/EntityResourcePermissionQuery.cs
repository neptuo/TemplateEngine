using Neptuo.Data.Entity.Queries;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity.Queries
{
    public class EntityResourcePermissionQuery : EntityQuery<ResourcePermission, IResourcePermissionFilter>, IResourcePermissionQuery
    {
        public EntityResourcePermissionQuery(DataContext dbContext)
            : base(dbContext.Permissions)
        { }

        protected override Expression BuildWhereExpression(Expression parameter)
        {
            Expression target = null;
            if (Filter != null)
            {
                if (Filter.ResourceName != null)
                    target = EntityQuerySearch.BuildTextSearch<ResourcePermission>(target, parameter, p => p.ResourceName, Filter.ResourceName);

                if (Filter.PermissionName != null)
                    target = EntityQuerySearch.BuildTextSearch<ResourcePermission>(target, parameter, p => p.PermissionName, Filter.PermissionName);

                if (Filter.RoleKey != null)
                    target = EntityQuerySearch.BuildIntSearch<ResourcePermission>(target, parameter, p => p.Role.Key, Filter.RoleKey);
            }
            return target;
        }

        protected override IResourcePermissionFilter CreateFilter()
        {
            return new ResourcePermissionFilter();
        }
    }
}

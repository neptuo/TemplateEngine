using Neptuo.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity
{
    public class EntityResourcePermissionRepository : EntityRepository<ResourcePermission, DataContext>, IResourcePermissionRepository
    {
        public EntityResourcePermissionRepository(DataContext dbContext)
            : base(dbContext)
        { }

        public ResourcePermission Create()
        {
            return DbContext.Permissions.Create();
        }
    }
}

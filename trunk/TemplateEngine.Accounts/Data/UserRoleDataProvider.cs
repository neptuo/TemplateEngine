using Neptuo.TemplateEngine.Accounts.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data
{
    public class UserRoleDataProvider : DataProviderBase<UserRole, IUserRoleQuery, IUserRoleRepository>
    {
        public UserRoleDataProvider(IUserRoleRepository repository, IActivator<IUserRoleQuery> queryFactory)
            : base(repository, queryFactory, repository)
        { }
    }
}

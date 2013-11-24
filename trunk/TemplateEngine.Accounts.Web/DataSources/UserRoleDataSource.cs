using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Queries;
using Neptuo.TemplateEngine.Web;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    public class UserRoleDataSource : IListDataSource
    {
        private IUserRoleQuery roleQuery;
        private IModelValueProviderFactory factory;

        public UserRoleDataSource(IUserRoleQuery roleQuery, IModelValueProviderFactory factory)
        {
            this.roleQuery = roleQuery;
            this.factory = factory;
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            IEnumerable<UserRole> data = roleQuery.Get();

            if (pageSize != null)
                data = data.Skip((pageIndex ?? 0) * pageSize.Value).Take(pageSize.Value);

            foreach (UserRole userRole in data)
                yield return factory.Create(userRole);
        }

        public int GetTotalCount()
        {
            return roleQuery.Get().Count();
        }
    }
}

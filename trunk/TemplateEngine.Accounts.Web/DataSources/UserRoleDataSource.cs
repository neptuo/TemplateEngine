using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Queries;
using Neptuo.TemplateEngine.Web.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    [WebDataSource]
    public class UserRoleDataSource : IListDataSource
    {
        private IUserRoleQuery roleQuery;

        public int? Key { get; set; }
        public string Name { get; set; }

        public UserRoleDataSource(IUserRoleQuery roleQuery)
        {
            this.roleQuery = roleQuery;
        }

        protected IEnumerable<UserRoleViewModel> GetDataOverride(int? pageIndex, int? pageSize)
        {
            IEnumerable<UserRole> data = roleQuery.Get();

            if (!String.IsNullOrEmpty(Name))
                data = data.Where(r => r.Name.Contains(Name));

            if (Key != null)
                data = data.Where(r => r.Key == Key);

            if (pageSize != null)
                data = data.Skip((pageIndex ?? 0) * pageSize.Value).Take(pageSize.Value);

            return data.OrderBy(r => r.Key).Select(r => new UserRoleViewModel(r.Key, r.Name, r.Description));
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            foreach (UserRoleViewModel userRole in GetDataOverride(pageIndex, pageSize))
                yield return userRole;
        }

        public int GetTotalCount()
        {
            return GetDataOverride(null, null).Count();
        }
    }
}

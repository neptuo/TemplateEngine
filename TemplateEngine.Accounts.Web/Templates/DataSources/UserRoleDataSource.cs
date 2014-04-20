using Neptuo.Data.Queries;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Templates.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    [WebDataSource]
    public class UserRoleDataSource : IListDataSource, IUserRoleDataSourceFilter
    {
        private IUserRoleQuery roleQuery;

        public int? Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public UserRoleDataSource(IUserRoleQuery roleQuery)
        {
            Guard.NotNull(roleQuery, "roleQuery");
            this.roleQuery = roleQuery;
        }

        protected void ApplyFilter()
        {
            if (!String.IsNullOrEmpty(Name))
                roleQuery.Filter.Name = TextSearch.Create(Name, TextSearchType.Contains, false);

            if (!String.IsNullOrEmpty(Description))
                roleQuery.Filter.Description = TextSearch.Create(Description, TextSearchType.Contains, false);

            if (Key != null)
                roleQuery.Filter.Key = IntSearch.Create(Key.Value);

            roleQuery.OrderBy(r => r.Name);
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            ApplyFilter();

            List<UserRoleViewModel> result = new List<UserRoleViewModel>();
            foreach (UserRole role in roleQuery.EnumeratePageItems(pageIndex, pageSize))
                result.Add(new UserRoleViewModel(role.Key, role.Name, role.Description));

            return result;
        }

        public int GetTotalCount()
        {
            ApplyFilter();
            return roleQuery.Count();
        }
    }
}

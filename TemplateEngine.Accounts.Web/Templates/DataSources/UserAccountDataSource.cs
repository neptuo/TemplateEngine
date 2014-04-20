using Neptuo.Data;
using Neptuo.Data.Queries;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Templates.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Templates.DataSources;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    [WebDataSource]
    public class UserAccountDataSource : IListDataSource, IDataSource, IUserAccountDataSourceFilter
    {
        private IUserAccountQuery userQuery;

        public int? Key { get; set; }
        public string Username { get; set; }
        public int? RoleKey { get; set; }

        public UserAccountDataSource(IUserAccountQuery userQuery)
        {
            Guard.NotNull(userQuery, "userQuery");
            this.userQuery = userQuery;
        }

        public object GetItem()
        {
            UserAccount userAccount = null;
            if (Key != null)
                userQuery.Filter.Key = IntSearch.Create(Key.Value);

            userAccount = userQuery.ResultSingle();

            if (userAccount == null)
                return null;

            return new UserAccountViewModel(userAccount.Key, userAccount.Username, userAccount.IsEnabled, userAccount.Roles.Select(r => new UserRoleRowViewModel(r.Key, r.Name)));
        }

        protected void ApplyFilter()
        {
            if (!String.IsNullOrEmpty(Username))
                userQuery.Filter.Username = TextSearch.Create(Username, TextSearchType.Contains);

            if (Key != null)
                userQuery.Filter.Key = IntSearch.Create(Key.Value);

            if (RoleKey != null)
                userQuery.Filter.RoleKey = RoleKey;

            userQuery.OrderBy(u => u.Username);

            //userQuery.OrderBy(u => u.Username);
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            ApplyFilter();

            List<UserAccountViewModel> result = new List<UserAccountViewModel>();
            foreach (UserAccount account in userQuery.EnumeratePageItems(pageIndex, pageSize))
                result.Add(new UserAccountViewModel(account.Key, account.Username, account.IsEnabled, GetRoles(account)));

            return result;
        }

        private IEnumerable<UserRoleRowViewModel> GetRoles(UserAccount account)
        {
            if (account.Roles == null)
                return Enumerable.Empty<UserRoleRowViewModel>();

            return account.Roles.Select(r => new UserRoleRowViewModel(r.Key, r.Name));
        }

        public int GetTotalCount()
        {
            ApplyFilter();
            return userQuery.Count();
        }
    }
}

using Neptuo.Data;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Queries;
using Neptuo.TemplateEngine.Web;
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
    public class UserAccountDataSource : IListDataSource, IDataSource
    {
        private IUserAccountQuery userQuery;

        public int? Key { get; set; }
        public string Username { get; set; }
        public int? RoleKey { get; set; }

        public UserAccountDataSource(IUserAccountQuery userQuery)
        {
            this.userQuery = userQuery;
        }

        public object GetItem()
        {
            UserAccount userAccount = null;
            if (Key != null)
                userAccount = userQuery.Get(Key.Value);
            else
                userQuery.Get().FirstOrDefault();

            if (userAccount == null)
                return null;

            return new UserAccountViewModel(userAccount.Key, userAccount.Username, userAccount.IsEnabled, userAccount.Roles.Select(r => new UserRoleRowViewModel(r.Key, r.Name)));
        }

        protected IEnumerable<UserAccountViewModel> GetDataOverride(int? pageIndex, int? pageSize)
        {
            IEnumerable<UserAccount> data = userQuery.Get();
            if (!String.IsNullOrEmpty(Username))
                data = data.Where(u => u.Username.Contains(Username));

            if (Key != null)
                data = data.Where(u => u.Key == Key);

            if (RoleKey != null)
                data = data.Where(u => u.Roles.Select(r => r.Key).Contains(RoleKey.Value));

            if (pageSize != null)
                data = data.Skip((pageIndex ?? 0) * pageSize.Value).Take(pageSize.Value);

            return data.OrderBy(u => u.Key).Select(u => new UserAccountViewModel(u.Key, u.Username, u.IsEnabled, u.Roles.Select(r => new UserRoleRowViewModel(r.Key, r.Name))));
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            return GetDataOverride(pageIndex, pageSize);
        }

        public int GetTotalCount()
        {
            return GetDataOverride(null, null).Count();
        }
    }
}

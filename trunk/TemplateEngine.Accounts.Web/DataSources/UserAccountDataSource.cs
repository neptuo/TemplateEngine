using Neptuo.Data;
using Neptuo.Data.Queries;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
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
    public class UserAccountDataSource : IListDataSource, IDataSource, IUserAccountFilter
    {
        private IUserAccountQuery userQuery;
        private IDeprecatedUserAccountQuery userQueryDeprecated;

        public int? Key { get; set; }
        public string Username { get; set; }
        public int? RoleKey { get; set; }

        public UserAccountDataSource(IDeprecatedUserAccountQuery userQueryDeprecated)
        {
            this.userQuery = null;
            this.userQueryDeprecated = userQueryDeprecated;
        }

        public object GetItem()
        {
            UserAccount userAccount = null;
            if (Key != null)
                userAccount = userQueryDeprecated.Get(Key.Value);
            else
                userQueryDeprecated.Get().FirstOrDefault();

            if (userAccount == null)
                return null;

            return new UserAccountViewModel(userAccount.Key, userAccount.Username, userAccount.IsEnabled, userAccount.Roles.Select(r => new UserRoleRowViewModel(r.Key, r.Name)));
        }

        protected IEnumerable<UserAccountViewModel> GetDataOverride(int? pageIndex, int? pageSize)
        {
            //if(Key != null)
            //    userQuery.Filter.Key = IntSearch.Create(Key.Value);

            //if(Username != null)
            //    userQuery.Filter.Username = TextSearch.Create(Username);


            IEnumerable<UserAccount> data = userQueryDeprecated.Get();
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

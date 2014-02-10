using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web.DataSources;
using SharpKit.Html;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    public class UserAccountDataSource : IListDataSource
    {
        private UserRepository userAccounts;

        public int? Key { get; set; }
        public string Username { get; set; }

        public UserAccountDataSource(UserRepository userAccounts)
        {
            Guard.NotNull(userAccounts, "userAccounts");
            this.userAccounts = userAccounts;
        }

        public void GetData(int? pageIndex, int? pageSize, Action<IListResult> callback)
        {
            if (pageSize != null)
                HtmlContext.setTimeout(() => callback(new ListResult(userAccounts.GetPage(pageIndex ?? 0, pageSize.Value), userAccounts.GetCount())), 200);
            else
                HtmlContext.setTimeout(() => callback(new ListResult(userAccounts.GetAll(), userAccounts.GetCount())), 1000);
        }
    }
}

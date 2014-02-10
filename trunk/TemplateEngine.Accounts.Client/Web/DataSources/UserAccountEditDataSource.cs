using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web.DataSources;
using SharpKit.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    public class UserAccountEditDataSource : IDataSource
    {
        private UserRepository userAccounts;

        public int Key { get; set; }

        public UserAccountEditDataSource(UserRepository userAccounts)
        {
            Guard.NotNull(userAccounts, "userAccounts");
            this.userAccounts = userAccounts;
        }

        public void GetItem(Action<object> callback)
        {
            HtmlContext.setTimeout(() =>
            {
                if (Key > 0)
                    callback(userAccounts.GetAll().FirstOrDefault(u => u.Key == Key));
                else
                    callback(new UserAccountEditModel { Key = 0, IsEnabled = true });
            }, 1000);
        }
    }
}

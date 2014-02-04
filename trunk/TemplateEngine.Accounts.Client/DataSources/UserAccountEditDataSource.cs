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
        public int Key { get; set; }

        public void GetItem(Action<object> callback)
        {
            HtmlContext.setTimeout(() =>
            {
                callback(new UserAccountEditModel
                {
                    Key = Key,
                    Username = "New user",
                    IsEnabled = true
                });
            }, 1000);
        }
    }
}

using Neptuo.TemplateEngine.Web.DataSources;
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
        public int? Key { get; set; }
        public string Username { get; set; }

        public int GetTotalCount()
        {
            return 0;
        }

        public void GetData(int? pageIndex, int? pageSize, Action<IEnumerable> callback)
        {
            callback(new List<object>
            {
                new UserAccountEditModel 
                {
                    Key = 1,
                    Username = "New user",
                    IsEnabled = true
                },
                new UserAccountEditModel 
                {
                    Key = 2,
                    Username = "New user",
                    IsEnabled = false
                },
                new UserAccountEditModel 
                {
                    Key = 3,
                    Username = "New user",
                    IsEnabled = false
                },
                new UserAccountEditModel 
                {
                    Key = 4,
                    Username = "New user",
                    IsEnabled = false
                },
                new UserAccountEditModel 
                {
                    Key = 5,
                    Username = "New user",
                    IsEnabled = true
                },
                new UserAccountEditModel 
                {
                    Key = 6,
                    Username = "New user",
                    IsEnabled = false
                },
                new UserAccountEditModel 
                {
                    Key = 7,
                    Username = "New user",
                    IsEnabled = false
                },
                new UserAccountEditModel 
                {
                    Key = 8,
                    Username = "New user",
                    IsEnabled = true
                },
                new UserAccountEditModel 
                {
                    Key = 9,
                    Username = "New user",
                    IsEnabled = true
                },
                new UserAccountEditModel 
                {
                    Key = 10,
                    Username = "New user",
                    IsEnabled = true
                },
                new UserAccountEditModel 
                {
                    Key = 11,
                    Username = "New user",
                    IsEnabled = true
                }
            });
        }
    }
}

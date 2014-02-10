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
    public class UserRoleDataSource : IListDataSource
    {
        public int? Key { get; set; }
        public string Name { get; set; }

        public int GetTotalCount()
        {
            return 0;
        }

        public void GetData(int? pageIndex, int? pageSize, Action<IListResult> callback)
        {
            HtmlContext.setTimeout(() =>
            {
                callback(new ListResult(new List<object>
                {
                    new UserRoleEditModel 
                    {
                        Key = 1,
                        Name = "Administrators",
                        Description = "System admins"
                    },
                    new UserRoleEditModel 
                    {
                        Key = 2,
                        Name = "Everyone",
                        Description = "Public (un-authenticated) users"
                    },
                    new UserRoleEditModel 
                    {
                        Key = 3,
                        Name = "WebAdmins",
                        Description = "Admins of web presentation"
                    },
                    new UserRoleEditModel 
                    {
                        Key = 4,
                        Name = "Articles",
                        Description = "Article writers"
                    }
                }, 4));
            }, 500);
        }
    }
}

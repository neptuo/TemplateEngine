using Neptuo.TemplateEngine.Templates.DataSources;
using Neptuo.Templates;
using SharpKit.Html;
using SharpKit.JavaScript;
using SharpKit.jQuery;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    public class UserAccountDataSource : DynamicListDataSourceProxy<UserAccountListResult>, IUserAccountDataSourceFilter
    {
        public int? Key { get; set; }
        public string Username { get; set; }
        public int? RoleKey { get; set; }

        public UserAccountDataSource(IVirtualUrlProvider urlProvider)
            : base(urlProvider, GetFilterProperties())
        { }

        private static IEnumerable<string> GetFilterProperties()
        {
            return new List<string> { "Key", "Username", "RoleKey" };
        }
    }
}

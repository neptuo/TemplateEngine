using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Web.DataSources;
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

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    public class UserAccountDataSource : ListDataSourceProxy<UserAccountListResult>, IUserAccountFilter
    {
        public int? Key { get; set; }
        public string Username { get; set; }
        public int? RoleKey { get; set; }

        public UserAccountDataSource(IVirtualUrlProvider urlProvider)
            : base(urlProvider)
        { }

        protected override void SetParameters(JsObjectBuilder parameterBuilder)
        {
            parameterBuilder
                .Set("Key", Key)
                .Set("Username", Username)
                .Set("RoleKey", RoleKey);
        }
    }
}

using Neptuo.TemplateEngine.Web.DataSources;
using Neptuo.Templates;
using SharpKit.Html;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.DataSources
{
    public class UserRoleDataSource : ListDataSourceProxy<UserRoleListResult>, IUserRoleFilter
    {
        public int? Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public UserRoleDataSource(IVirtualUrlProvider urlProvider)
            : base(urlProvider)
        { }

        protected override void SetParameters(JsObjectBuilder parameterBuilder)
        {
            parameterBuilder
                .Set("Key", Key)
                .Set("Name", Name)
                .Set("Description", Description);
        }
    }
}

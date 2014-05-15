using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Templates.DataSources;
using Neptuo.Templates;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    public class UserLogDataSource : ListDataSourceProxy<ListResult>, IUserLogDataSourceFilter
    {
        public int? UserKey { get; set; }

        public UserLogDataSource(IVirtualUrlProvider urlProvider)
            : base(urlProvider)
        { }

        protected override void SetParameters(JsObjectBuilder parameterBuilder)
        {
            parameterBuilder.Set("UserKey", UserKey);
        }
    }
}

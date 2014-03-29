using Neptuo.TemplateEngine.Web.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserAccountListResult : ListResult
    {
        public UserAccountListResult(IEnumerable data, int totalCount)
            : base(data, totalCount)
        { }
    }
}

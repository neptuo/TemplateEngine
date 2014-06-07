using Neptuo.TemplateEngine.Templates.DataSources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserRoleListResult : ListResult
    {
        public UserRoleListResult(IEnumerable data, int totalCount)
            : base(data, totalCount)
        { }
    }
}

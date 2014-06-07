using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Templates.DataSources;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserLogListResult :  ListResult
    {
        public UserLogListResult(IEnumerable data, int totalCount)
            : base(data, totalCount)
        { }
    }
}

using Neptuo.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Queries
{
    public class UserLogFilter : IUserLogFilter
    {
        public Guid? Key { get; set; }
        public IntSearch UserKey { get; set; }
    }
}

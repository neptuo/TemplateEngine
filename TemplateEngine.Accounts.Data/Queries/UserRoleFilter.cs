using Neptuo.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Queries
{
    public class UserRoleFilter : IUserRoleFilter
    {
        public IntSearch Key { get; set; }
        public TextSearch Name { get; set; }
        public TextSearch Description { get; set; }
    }
}

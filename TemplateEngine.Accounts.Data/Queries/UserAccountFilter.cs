using Neptuo.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Queries
{
    public class UserAccountFilter : IUserAccountFilter
    {
        public IntSearch Key { get; set; }
        public TextSearch Username { get; set; }
        public TextSearch Password { get; set; }
        public bool? IsEnabled { get; set; }
    }
}

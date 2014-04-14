using Neptuo.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Queries
{
    public interface IUserAccountFilter
    {
        IntSearch Key { get; set; }
        TextSearch Username { get; set; }
        TextSearch Password { get; set; }
        bool? IsEnabled { get; set; }
        int? RoleKey { get; set; }
    }
}

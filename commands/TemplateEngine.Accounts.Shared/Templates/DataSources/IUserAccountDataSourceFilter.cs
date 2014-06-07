using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    public interface IUserAccountDataSourceFilter
    {
        int? Key { get; set; }
        string Username { get; set; }
        int? RoleKey { get; set; }
    }
}

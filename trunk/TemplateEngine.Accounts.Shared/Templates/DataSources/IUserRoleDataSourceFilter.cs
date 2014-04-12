using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    public interface IUserRoleDataSourceFilter
    {
        int? Key { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}

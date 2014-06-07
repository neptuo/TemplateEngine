using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    public interface IUserLogDataSourceFilter
    {
        int? UserKey { get; }
    }
}

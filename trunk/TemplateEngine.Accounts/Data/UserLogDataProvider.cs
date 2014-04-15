using Neptuo.TemplateEngine.Accounts.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data
{
    public class UserLogDataProvider : DataProviderBase<UserLog, IUserLogQuery, IUserLogRepository>
    {
        public UserLogDataProvider(IUserLogRepository repository, IActivator<IUserLogQuery> queryFactory)
            : base(repository, queryFactory, repository)
        { }
    }
}

using Neptuo.Data.Entity.Queries;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Data.Entity.Queries
{
    public class EntityUserLogQuery : EntityQuery<UserLog, IUserLogFilter>, IUserLogQuery
    {
        public EntityUserLogQuery(DataContext dbContext)
            : base(dbContext.UserLogs)
        { }

        protected override Expression BuildWhereExpression(Expression parameter)
        {
            throw new NotImplementedException();
        }

        protected override IUserLogFilter CreateFilter()
        {
            return new UserLogFilter();
        }
    }
}

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
            Expression target = null;

            //TODO: Create search for Key 
            //if (Filter.Key != null)
            //    target = EntityQuerySearch.BuildIntSearch<UserLog>(target, parameter, l => l.Key, Filter.Key);

            if (Filter.UserKey != null)
                target = EntityQuerySearch.BuildIntSearch<UserLog>(target, parameter, l => l.User.Key, Filter.UserKey); //TODO: Read while property path

            return target;
        }

        protected override IUserLogFilter CreateFilter()
        {
            return new UserLogFilter();
        }
    }
}

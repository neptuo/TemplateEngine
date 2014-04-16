using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Templates.DataSources;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    [WebDataSource]
    public class UserLogDataSource : IListDataSource
    {
        private readonly IUserLogQuery query;

        public UserLogDataSource(IUserLogQuery query)
        {
            Guard.NotNull(query, "query");
            this.query = query;
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            return query.EnumerateItems().Select(l => new UserLogViewModel(
                l.Key.ToString(),
                new UserAccountRowViewModel(l.User.Key, l.User.Username),
                l.SignedIn,
                l.SignedOut,
                l.LastActivity,
                false
            ));
        }

        public int GetTotalCount()
        {
            return query.Count();
        }
    }
}

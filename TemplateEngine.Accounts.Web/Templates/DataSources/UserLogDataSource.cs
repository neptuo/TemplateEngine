using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Templates.DataSources;
using Neptuo.Data.Queries;

namespace Neptuo.TemplateEngine.Accounts.Templates.DataSources
{
    [WebDataSource]
    public class UserLogDataSource : IListDataSource, IUserLogDataSourceFilter
    {
        private readonly IUserLogQuery query;

        public int? UserKey { get; set; }

        public UserLogDataSource(IUserLogQuery query)
        {
            Guard.NotNull(query, "query");
            this.query = query;
        }

        protected void ApplyFilter(int? pageIndex, int? pageSize)
        {
            if (UserKey != null)
                query.Filter.UserKey = IntSearch.Create(UserKey.Value);

            query.OrderByDescending(l => l.SignedIn);
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            ApplyFilter(pageIndex, pageSize);

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
            ApplyFilter(null, null);
            return query.Count();
        }
    }
}

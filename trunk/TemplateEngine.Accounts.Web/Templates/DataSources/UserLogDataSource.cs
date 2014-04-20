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
        private readonly IUserLogContext userContext;

        public int? UserKey { get; set; }

        public UserLogDataSource(IUserLogQuery query, IUserLogContext userContext)
        {
            Guard.NotNull(query, "query");
            Guard.NotNull(userContext, "userContext");
            this.query = query;
            this.userContext = userContext;
        }

        protected void ApplyFilter()
        {
            if (UserKey != null)
                query.Filter.UserKey = IntSearch.Create(UserKey.Value);

            query.OrderByDescending(l => l.SignedIn);
        }

        public IEnumerable GetData(int? pageIndex, int? pageSize)
        {
            ApplyFilter();

            return query.EnumeratePageItems(pageIndex, pageSize).Select(l => new UserLogViewModel(
                l.Key.ToString(),
                new UserAccountRowViewModel(l.User.Key, l.User.Username),
                l.SignedIn,
                l.SignedOut,
                l.LastActivity,
                userContext.Log.Key == l.Key
            ));
        }

        public int GetTotalCount()
        {
            ApplyFilter();
            return query.Count();
        }
    }
}

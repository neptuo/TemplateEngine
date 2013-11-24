using Neptuo.TemplateEngine.Accounts.Queries;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.Presenters
{
    public class UserListPresenter : PresentationListControlBase<UserAccount>
    {
        protected IUserAccountQuery UserQuery { get; private set; }

        public UserListPresenter(IComponentManager componentManager, PresentationConfiguration<UserAccount> configuration, IUserAccountQuery userQuery)
            : base(componentManager, configuration)
        {
            UserQuery = userQuery;
        }

        protected override IEnumerable<UserAccount> LoadData()
        {
            return UserQuery.Get();
        }
    }
}

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
        protected IUserQuery UserQuery { get; private set; }

        public UserListPresenter(IComponentManager componentManager, TemplateContentStorageStack viewStorage, PresentationConfiguration<UserAccount> configuration, IUserQuery userQuery)
            : base(componentManager, viewStorage, configuration)
        {
            UserQuery = userQuery;
        }

        public override void OnInit()
        {
            Models.AddRange(UserQuery.Get());
            base.OnInit();
        }

        //protected override void RenderBody(IHtmlWriter writer)
        //{
        //    writer.Tag("ul");
        //    foreach (UserAccount user in UserQuery.Get())
        //        writer.Tag("li").Content(user.Username).CloseTag();

        //    writer.CloseTag();
        //}
    }
}

using Neptuo.TemplateEngine.Accounts.Queries;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.Controls
{
    [Html("div")]
    public class UserListControl : ContentControlBase
    {
        private IUserQuery userQuery;

        public UserListControl(IComponentManager componentManager, IUserQuery userQuery)
            : base(componentManager)
        {
            this.userQuery = userQuery;
        }

        protected override void RenderBody(IHtmlWriter writer)
        {
            writer.Tag("ul");
            foreach (UserAccount user in userQuery.Get())
                writer.Tag("li").Content(user.Username).CloseTag();

            writer.CloseTag();
        }
    }
}

using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neptuo.TemplateEngine.Providers;

namespace Neptuo.TemplateEngine.Accounts.Hosting.Bootstrap
{
    public abstract class AccountBootstrapTaskBase
    {
        protected void SetupForms(IFormUriRegistry formRegistry, ITemplateUrlFormatter formatter)
        {
            formRegistry
                .Register("Accounts.Login", formatter.FormatUrl("~/Accounts/Login"))

                .Register("Accounts.User.List", formatter.FormatUrl("~/Accounts/UserList"))
                .Register("Accounts.User.Edit", formatter.FormatUrl("~/Accounts/UserEdit"))

                .Register("Accounts.Role.List", formatter.FormatUrl("~/Accounts/RoleList"))
                .Register("Accounts.Role.Edit", formatter.FormatUrl("~/Accounts/RoleEdit"))

                .Register("Accounts.Log.List", formatter.FormatUrl("~/Accounts/LogList"))

                .Register("Accounts.Permission.List", formatter.FormatUrl("~/Accounts/PermissionList"));
        }

        protected void SetupGlobalNavigations(GlobalNavigationCollection globalNavigations)
        {
            globalNavigations
                .Add("Accounts.User.Deleted", (FormUri)"Accounts.User.List")
                .Add("Accounts.User.Created", (FormUri)"Accounts.User.List")
                .Add("Accounts.User.Updated", (FormUri)"Accounts.User.List")

                .Add("Accounts.Role.Deleted", (FormUri)"Accounts.Role.List")
                .Add("Accounts.Role.Created", (FormUri)"Accounts.Role.List")
                .Add("Accounts.Role.Updated", (FormUri)"Accounts.Role.List")

                .Add("Accounts.Permission.Updated", (FormUri)"Accounts.Role.List")

                .Add("Accounts.LoggedIn", (FormUri)"Accounts.User.List")
                .Add("Accounts.LoggedOut", (FormUri)"Accounts.Login");
        }
    }
}

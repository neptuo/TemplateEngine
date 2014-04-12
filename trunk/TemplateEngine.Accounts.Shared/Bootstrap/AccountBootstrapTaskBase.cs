using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Controllers;
using Neptuo.TemplateEngine.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Bootstrap
{
    public abstract class AccountBootstrapTaskBase
    {
        protected void SetupForms(IFormUriRegistry formRegistry)
        {
            formRegistry
                .Register("Accounts.User.List", TemplateRouteParameterBase.FormatUrl("~/Accounts/UserList"))
                .Register("Accounts.User.Edit", TemplateRouteParameterBase.FormatUrl("~/Accounts/UserEdit"))

                .Register("Accounts.Role.List", TemplateRouteParameterBase.FormatUrl("~/Accounts/RoleList"))
                .Register("Accounts.Role.Edit", TemplateRouteParameterBase.FormatUrl("~/Accounts/RoleEdit"));
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
                
                .Add("Accounts.LoggedIn", (FormUri)"Accounts.User.List");
        }
    }
}

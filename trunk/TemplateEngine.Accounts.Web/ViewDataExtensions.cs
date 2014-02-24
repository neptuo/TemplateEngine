using Neptuo.TemplateEngine.Accounts.Commands;
using Neptuo.TemplateEngine.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web
{
    public static class ViewDataExtensions
    {
        #region EditUserCommand

        public static UserAccountEditCommand GetEditUserAccount(this IViewData viewData)
        {
            return viewData.Get<UserAccountEditCommand>("EditUserCommnad");
        }

        public static void SetEditUserAccount(this IViewData viewData, UserAccountEditCommand model)
        {
            viewData.Set("EditUserCommnad", model);
        }

        #endregion

        #region EditUserRoleCommand

        public static UserRoleEditCommand GetEditUserRole(this IViewData viewData)
        {
            return viewData.Get<UserRoleEditCommand>("EditUserRoleCommand");
        }

        public static void SetEditUserRole(this IViewData viewData, UserRoleEditCommand model)
        {
            viewData.Set("EditUserRoleCommand", model);
        }

        #endregion
    }
}

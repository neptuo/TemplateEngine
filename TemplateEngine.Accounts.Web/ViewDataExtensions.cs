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
        #region UserAccountEditCommand

        public static UserAccountEditCommand GetUserAccountEdit(this IViewData viewData)
        {
            return viewData.Get<UserAccountEditCommand>("UserAccountEditCommand");
        }

        public static void SetUserAccountEdit(this IViewData viewData, UserAccountEditCommand model)
        {
            viewData.Set("UserAccountEditCommand", model);
        }

        #endregion

        #region UserAccountCreateCommand

        public static UserAccountCreateCommand GetUserAccountCreate(this IViewData viewData)
        {
            return viewData.Get<UserAccountCreateCommand>("UserAccountCreateCommand");
        }

        public static void SetUserAccountCreate(this IViewData viewData, UserAccountCreateCommand model)
        {
            viewData.Set("UserAccountCreateCommand", model);
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

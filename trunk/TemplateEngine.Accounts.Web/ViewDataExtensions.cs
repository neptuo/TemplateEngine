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

        public static EditUserCommand GetEditUserAccount(this IViewData viewData)
        {
            return viewData.Get<EditUserCommand>("EditUserCommnad");
        }

        public static void SetEditUserAccount(this IViewData viewData, EditUserCommand model)
        {
            viewData.Set("EditUserCommnad", model);
        }

        #endregion

        #region EditUserRoleCommand

        public static EditUserRoleCommand GetEditUserRole(this IViewData viewData)
        {
            return viewData.Get<EditUserRoleCommand>("EditUserRoleCommand");
        }

        public static void SetEditUserRole(this IViewData viewData, EditUserRoleCommand model)
        {
            viewData.Set("EditUserRoleCommand", model);
        }

        #endregion
    }
}

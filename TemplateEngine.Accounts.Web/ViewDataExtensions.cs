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
        public static EditUserCommand GetEditUser(this IViewData viewData)
        {
            return viewData.Get<EditUserCommand>("EditUserCommnad");
        }

        public static void SetEditUser(this IViewData viewData, EditUserCommand model)
        {
            viewData.Set("EditUserCommnad", model);
        }
    }
}

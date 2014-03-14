using Neptuo.TemplateEngine.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    public class TemplateRoute : IRoute
    {
        public IApplication Application { get; private set; }

        public TemplateRoute(IApplication application)
        {
            Guard.NotNull(application, "application");
            Application = application;
        }

        public RouteData GetRouteData(RequestContext context)
        {
            string viewPath = MapView(context.Url);
            if (String.IsNullOrEmpty(viewPath))
                return null;

            IDependencyContainer childContainer = Application.DependencyContainer;

            string[] toUpdate = Application.DefaultToUpdate;
            if (context.CustomValues.ContainsKey("ToUpdate"))
            {
                string[] value = (string[])context.CustomValues["ToUpdate"];
                if (value != null)
                    toUpdate = value;
            }

            if (context.CustomValues.ContainsKey("Messages"))
                childContainer.RegisterInstance((MessageStorage)context.CustomValues["Messages"]);

            return new RouteData(
                context, 
                new TemplateRouteHandler(
                    Application.MainView, 
                    viewPath,
                    toUpdate, 
                    childContainer
                ), 
                new RouteValueDictionary()
            );
        }
        
        public static string MapView(string url)
        {
            if (url.Contains("/Home.aspx"))
                return "~/Views/Home.view";

            if (url.Contains("/Accounts/UserList.aspx"))
                return "~/Views/Accounts/UserList.view";

            if (url.Contains("/Accounts/UserEdit.aspx"))
                return "~/Views/Accounts/UserEdit.view";

            if (url.Contains("/Accounts/RoleList.aspx"))
                return "~/Views/Accounts/RoleList.view";

            if (url.Contains("/Accounts/RoleEdit.aspx"))
                return "~/Views/Accounts/RoleEdit.view";

            return null;
        }
    }
}

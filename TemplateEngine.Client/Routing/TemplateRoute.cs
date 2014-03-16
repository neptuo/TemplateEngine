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
        public string UrlSuffix { get; private set; }
        public IApplication Application { get; private set; }

        public TemplateRoute(string urlSuffix, IApplication application)
        {
            Guard.NotNull(application, "application");
            UrlSuffix = urlSuffix;
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
        
        public string MapView(string url)
        {
            if (UrlSuffix != null && !url.EndsWith(UrlSuffix))
                return null;

            if (UrlSuffix != null)
                url = url.Replace(UrlSuffix, ".view");
            else
                url = url + ".view";

            string viewPath = "~/Views" + url;
            return viewPath;
        }
    }
}

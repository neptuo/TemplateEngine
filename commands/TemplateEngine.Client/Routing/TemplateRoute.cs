using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Routing
{
    /// <summary>
    /// Template route tha maps url ~/Accounts/UserList.html to views ~/Views/Accounts/UserList.view.
    /// </summary>
    public class TemplateRoute : IRoute
    {
        /// <summary>
        /// Url suffix.
        /// </summary>
        public string UrlSuffix { get; private set; }

        /// <summary>
        /// Instance of application.
        /// </summary>
        public IApplication Application { get; private set; }

        /// <summary>
        /// Creates new instance.
        /// </summary>
        /// <param name="urlSuffix">Url suffix.</param>
        /// <param name="application">Instance of application.</param>
        public TemplateRoute(string urlSuffix, IApplication application)
        {
            Guard.NotNull(application, "application");
            UrlSuffix = urlSuffix;
            Application = application;
        }

        /// <summary>
        /// Tries to map url to view path and if succeeds returns <see cref="RouteData"/> for that url.
        /// </summary>
        /// <param name="context">Request context.</param>
        /// <returns>Route data if succeeds mapping url to view path.</returns>
        public RouteData GetRouteData(RequestContext context)
        {
            string viewPath = MapView(context.Url);
            if (String.IsNullOrEmpty(viewPath))
                return null;

            IDependencyContainer childContainer = Application.DependencyContainer.CreateChildContainer();

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
        
        /// <summary>
        /// Maps urls to view paths.
        /// </summary>
        /// <param name="url">Virtual url to map.</param>
        /// <returns>Virtual view path for <paramref name="url"/>.</returns>
        public virtual string MapView(string url)
        {
            // Do stuff only if url ends with suffix.
            if (UrlSuffix != null && !url.EndsWith(UrlSuffix))
                return null;

            // If url starts with application path, remove that part.
            if (Application.ApplicationPath.Length > 1 && url.StartsWith(Application.ApplicationPath))
                url = url.Substring(Application.ApplicationPath.Length);

            // Replace url suffix with view suffix.
            if (UrlSuffix != null)
                url = url.Replace(UrlSuffix, ".view");
            else
                url = url + ".view";

            string viewPath = "~/Views" + url;
            return viewPath;
        }
    }
}

using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Routing;
using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Hosting
{
    /// <summary>
    /// Maps request to static .view files in ~/views directory.
    /// </summary>
    public class TemplateHttpHandler : TemplateHttpHandlerBase
    {
        public string TemplateUrl { get; private set; }
        public IViewService ViewService { get; private set; }
        public IViewServiceContext ViewServiceContext { get; private set; }

        public TemplateHttpHandler(string templateUrl, IViewService viewService, IViewServiceContext viewServiceContext)
        {
            Guard.NotNullOrEmpty(templateUrl, "templateUrl");
            Guard.NotNull(viewService, "viewService");
            Guard.NotNull(viewServiceContext, "viewServiceContext");
            TemplateUrl = templateUrl;
            ViewService = viewService;
            ViewServiceContext = viewServiceContext;
        }

        //protected override IComponentManager GetComponentManager(IViewServiceContext viewServiceContext, HttpContext httpContext)
        //{
        //    return new RequestComponentManager(httpContext.Request.Form);
        //}

        protected override BaseGeneratedView GetCurrentView(HttpContext context)
        {
            return (BaseGeneratedView)ViewService.Process(TemplateUrl, ViewServiceContext);
        }

        protected override IDependencyContainer GetDependencyContainer()
        {
            return ViewServiceContext.DependencyProvider.CreateChildContainer();
        }

        protected override FormUri GetCurrentFormUri(HttpContext context)
        {
            return GetCurrentFormUri(TemplateUrl);
        }

        public static FormUri GetCurrentFormUri(string templateUrl)
        {
            Guard.NotNull(templateUrl, "templateUrl");

            string uri = templateUrl
                .Replace("\\", "/")
                .Replace("~/Views/", "~/")
                .Replace(TemplateRouteParameterBase.TemplatePathSuffix, TemplateRouteParameterBase.TemplateUrlSuffix)
                .ToLowerInvariant();

            FormUri formUri = FormUriTable.Repository.EnumerateForms().FirstOrDefault(f => f.Url().ToLowerInvariant() == uri);
            return formUri;
        }
    }
}

using Neptuo.TemplateEngine.Web.Compilation;
using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Backend.Web
{
    public class ViewGeneratorHttpHandler : IHttpHandler
    {
        private IJavascriptSourceViewService viewService;
        private IDependencyProvider dependencyProvider;
        
        public bool IsReusable
        {
            get { return false; }
        }

        public ViewGeneratorHttpHandler(IJavascriptSourceViewService viewService, IDependencyProvider dependencyProvider)
        {
            this.viewService = viewService;
            this.dependencyProvider = dependencyProvider;
        }

        public void ProcessRequest(HttpContext context)
        {
            foreach (string viewPath in Directory.GetFiles(context.Server.MapPath("~/Views"), "*.view", SearchOption.AllDirectories))
            {
                string viewContent = File.ReadAllText(viewPath);

                context.Response.ContentType = "text/javascript";
                context.Response.Write("//" + viewPath);
                context.Response.Write(Environment.NewLine);
                context.Response.Write(viewService.GenerateJavascript(viewContent, new ViewServiceContext(dependencyProvider), viewService.NamingService.FromContent(viewContent)));
                context.Response.Write(Environment.NewLine);
            }
        }
    }
}

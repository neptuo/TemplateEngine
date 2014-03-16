using Neptuo.Security.Cryptography;
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
    public class JavascriptViewGeneratorHttpHandler : IHttpHandler
    {
        private JavascriptViewGeneratorConfiguration configuration;
        private IJavascriptSourceViewService viewService;
        private IDependencyProvider dependencyProvider;

        public bool IsReusable
        {
            get { return false; }
        }

        public JavascriptViewGeneratorHttpHandler(JavascriptViewGeneratorConfiguration configuration, IJavascriptSourceViewService viewService, IDependencyProvider dependencyProvider)
        {
            this.configuration = configuration;
            this.viewService = viewService;
            this.dependencyProvider = dependencyProvider;
        }

        public void ProcessRequest(HttpContext context)
        {
            StringBuilder contentBuilder = new StringBuilder();
            StringBuilder appendBuilder = new StringBuilder();

            context.Response.ContentType = "text/javascript";
            foreach (string viewPath in Directory.GetFiles(context.Server.MapPath(configuration.ViewDirectory), "*.view", SearchOption.AllDirectories))
            {
                DateTime viewLastModified = File.GetLastWriteTime(viewPath);
                string tempViewPath = GetTempJavascriptFilePath(configuration, viewPath);
                string viewContent = File.ReadAllText(viewPath);
                string virtualViewPath = RelativePath(context.Server, viewPath, context.Request);

                INaming classNaming = viewService.NamingService.FromFile(virtualViewPath);
                appendBuilder.AppendFormat(
                    "Neptuo.TemplateEngine.Web.StaticViewActivator.Add('{0}', Typeof(Neptuo.Templates.{1}.ctor));",
                    virtualViewPath, //.Replace("~/Views/", "~/")
                    classNaming.ClassName
                );
                appendBuilder.AppendLine();
                
                if (File.Exists(tempViewPath))
                {
                    DateTime tempLastModified = File.GetLastWriteTime(tempViewPath);
                    if (tempLastModified >= viewLastModified)
                    {
                        contentBuilder.AppendLine("/*" + viewPath + " - CACHE*/");
                        contentBuilder.AppendLine(File.ReadAllText(tempViewPath));
                        continue;
                    }
                }

                string javascriptContent = viewService.GenerateJavascript(viewContent, new ViewServiceContext(dependencyProvider), classNaming);
                javascriptContent = RewriteJavascriptContent(javascriptContent);
                File.WriteAllText(tempViewPath, javascriptContent);
                contentBuilder.AppendLine(javascriptContent);

            }

            context.Response.Write(contentBuilder.ToString());
            context.Response.Write("JsRuntime.Start();");
            context.Response.Write(appendBuilder.ToString());
        }

        private string RewriteJavascriptContent(string content)
        {
            //content = content.Replace(
            //    "new Neptuo.TemplateEngine.Web.Controls.FileTemplate.ctor(this.dependencyProvider, this.componentManager, (Cast((this.dependencyProvider.Resolve(Typeof(Neptuo.Templates.Compilation.IViewService.ctor), null)), Neptuo.Templates.Compilation.IViewService.ctor)))", 
            //    "new Neptuo.TemplateEngine.Web.Controls.FileTemplate2.ctor(this.dependencyProvider, this.componentManager)"
            //);
            //content = content.Replace(
            //    "Neptuo.TemplateEngine.Web.Controls.FileTemplate.ctor", 
            //    "Neptuo.TemplateEngine.Web.Controls.FileTemplate2.ctor"
            //);
            return content;
        }

        private string GetTempJavascriptFilePath(JavascriptViewGeneratorConfiguration configuration, string viewPath)
        {
            if (!Directory.Exists(configuration.TempDirectory))
                Directory.CreateDirectory(configuration.TempDirectory);

            return Path.Combine(configuration.TempDirectory, HashHelper.Sha1(viewPath) + ".js");
        }

        public static string RelativePath(HttpServerUtility srv, string path, HttpRequest context)
        {
            return path.Replace(context.ServerVariables["APPL_PHYSICAL_PATH"], "~/").Replace(@"\", "/");
        }
    }
}

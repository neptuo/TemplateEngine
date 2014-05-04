using Neptuo.Security.Cryptography;
using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Security;
using Neptuo.TemplateEngine.Templates.Compilation;
using Neptuo.TemplateEngine.Web.ViewBundles;
using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Hosting.Integration
{
    public class JavascriptViewGeneratorHttpHandler : IHttpHandler
    {
        private JavascriptViewGeneratorConfiguration configuration;
        private ViewService viewService;
        private IDependencyProvider dependencyProvider;
        private IViewBundleCollection bundles;

        public bool IsReusable
        {
            get { return false; }
        }

        public JavascriptViewGeneratorHttpHandler(JavascriptViewGeneratorConfiguration configuration, ViewService viewService, IDependencyProvider dependencyProvider)
        {
            this.configuration = configuration;
            this.viewService = viewService;
            this.dependencyProvider = dependencyProvider;
            this.bundles = ViewBundleTable.Bundles;
        }

        public void ProcessRequest(HttpContext context)
        {
            StringBuilder contentBuilder = new StringBuilder();
            StringBuilder appendBuilder = new StringBuilder();

            string bundleName = context.Request.Params["Path"];
            IViewBundle currentBundle = null;
            if (String.IsNullOrEmpty(bundleName) || !bundles.TryGet(bundleName, out currentBundle))
                currentBundle = new GreedyViewBundle();

            context.Response.ContentType = "text/javascript";
            foreach (string viewPath in Directory.GetFiles(context.Server.MapPath(configuration.ViewDirectory), "*.view", SearchOption.AllDirectories))
            {
                DateTime viewLastModified = File.GetLastWriteTime(viewPath);
                string tempViewPath = GetTempJavascriptFilePath(configuration, viewPath);
                string viewContent = File.ReadAllText(viewPath);
                string virtualViewPath = RelativePath(context.Server, viewPath, context.Request);
                if (IsViewAllow(virtualViewPath))
                {
                    if (currentBundle.ContainsView(virtualViewPath))
                    {
                        INaming classNaming = viewService.NamingService.FromFile(virtualViewPath);
                        appendBuilder.AppendFormat(
                            "Neptuo.TemplateEngine.Templates.StaticViewActivator.Add('{0}', Typeof(Neptuo.Templates.{1}.ctor));",
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

                        string javascriptContent = viewService.GenerateJavascriptSourceCodeFromView(viewContent, new ViewServiceContext(dependencyProvider), classNaming);
                        javascriptContent = RewriteJavascriptContent(javascriptContent);
                        File.WriteAllText(tempViewPath, javascriptContent);
                        contentBuilder.AppendLine(javascriptContent);
                    }
                }
            }

            context.Response.Write(contentBuilder.ToString());
            context.Response.Write("JsRuntime.Start();");
            context.Response.Write(appendBuilder.ToString());
        }

        private bool IsViewAllow(string virtualViewPath)
        {
            FormUri formUri = TemplateHttpHandler.GetCurrentFormUri(virtualViewPath);
            if (formUri == null)
                return true;

            //return dependencyProvider.Resolve<IUserContext>().Permissions.IsAllowed(formUri.Identifier(), "ReadWrite");
            return true;
        }

        private string RewriteJavascriptContent(string content)
        {
            //content = content.Replace(
            //    "new Neptuo.TemplateEngine.Templates.Controls.FileTemplate.ctor(this.dependencyProvider, this.componentManager, (Cast((this.dependencyProvider.Resolve(Typeof(Neptuo.Templates.Compilation.IViewService.ctor), null)), Neptuo.Templates.Compilation.IViewService.ctor)))", 
            //    "new Neptuo.TemplateEngine.Templates.Controls.FileTemplate2.ctor(this.dependencyProvider, this.componentManager)"
            //);
            //content = content.Replace(
            //    "Neptuo.TemplateEngine.Templates.Controls.FileTemplate.ctor", 
            //    "Neptuo.TemplateEngine.Templates.Controls.FileTemplate2.ctor"
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

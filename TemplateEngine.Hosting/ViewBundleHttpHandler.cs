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

namespace Neptuo.TemplateEngine.Hosting
{
    public class ViewBundleHttpHandler : IHttpHandler
    {
        private ViewBundleHttpHandlerConfiguration configuration;
        private ViewService viewService;
        private IDependencyProvider dependencyProvider;
        private IViewBundleCollection bundles;

        public bool IsReusable
        {
            get { return false; }
        }

        public ViewBundleHttpHandler(ViewBundleHttpHandlerConfiguration configuration, ViewService viewService, IDependencyProvider dependencyProvider)
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
                ProcessGreedyRequest(context, contentBuilder, appendBuilder);
            else
                ProcessBundleRequest(context, currentBundle, contentBuilder, appendBuilder);

            context.Response.ContentType = "text/javascript";
            context.Response.Write(contentBuilder.ToString());
            context.Response.Write("JsRuntime.Start();");
            context.Response.Write(appendBuilder.ToString());
        }

        private void ProcessBundleRequest(HttpContext context, IViewBundle currentBundle, StringBuilder contentBuilder, StringBuilder appendBuilder)
        {
            foreach (string scriptPath in currentBundle.EnumerateScripts())
            {
                string javascriptContent = File.ReadAllText(context.Server.MapPath(scriptPath));
                contentBuilder.AppendLine(javascriptContent);
            }

            foreach (string viewPath in currentBundle.EnumerateViews())
                ProcessViewPath(context, viewPath, contentBuilder, appendBuilder);
        }

        private void ProcessGreedyRequest(HttpContext context, StringBuilder contentBuilder, StringBuilder appendBuilder)
        {
            foreach (string viewPath in Directory.GetFiles(context.Server.MapPath(configuration.ViewDirectory), "*.view", SearchOption.AllDirectories))
            {
                string virtualViewPath = RelativePath(context.Server, viewPath, context.Request);
                ProcessViewPath(context, virtualViewPath, contentBuilder, appendBuilder);
            }
        }

        private void ProcessViewPath(HttpContext context, string virtualViewPath, StringBuilder contentBuilder, StringBuilder appendBuilder)
        {
            string viewPath = context.Server.MapPath(virtualViewPath);
            DateTime viewLastModified = File.GetLastWriteTime(viewPath);
            string tempViewPath = GetTempJavascriptFilePath(viewPath);
            if (File.Exists(viewPath))
            {
                string viewContent = File.ReadAllText(viewPath);

                if (IsViewAllowed(virtualViewPath))
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
                            return;
                        }
                    }

                    string javascriptContent = viewService.GenerateJavascriptSourceCodeFromView(viewContent, new ViewServiceContext(dependencyProvider), classNaming);
                    File.WriteAllText(tempViewPath, javascriptContent);
                    contentBuilder.AppendLine(javascriptContent);
                }
            }
        }

        private bool IsViewAllowed(string virtualViewPath)
        {
            FormUri formUri = TemplateHttpHandler.GetCurrentFormUri(virtualViewPath);
            if (formUri == null)
                return true;

            //return dependencyProvider.Resolve<IUserContext>().Permissions.IsAllowed(formUri.Identifier(), "ReadWrite");
            return true;
        }

        private string GetTempJavascriptFilePath(string viewPath)
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

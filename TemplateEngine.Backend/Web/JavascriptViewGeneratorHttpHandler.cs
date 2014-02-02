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
            context.Response.ContentType = "text/javascript";
            foreach (string viewPath in Directory.GetFiles(context.Server.MapPath(configuration.ViewDirectory), "*.view", SearchOption.AllDirectories))
            {
                DateTime viewLastModified = File.GetLastWriteTime(viewPath);
                string tempViewPath = GetTempJavascriptFilePath(configuration, viewPath);
                string viewContent = null;
                if (File.Exists(tempViewPath))
                {
                    DateTime tempLastModified = File.GetLastWriteTime(tempViewPath);
                    if (tempLastModified >= viewLastModified)
                    {
                        WriteJavascriptFile(
                            context,
                            viewPath + " - CACHE",
                            File.ReadAllText(tempViewPath)
                        );
                        continue;
                    }
                }

                viewContent = File.ReadAllText(viewPath);

                try
                {
                    string javascriptContent = viewService.GenerateJavascript(viewContent, new ViewServiceContext(dependencyProvider), viewService.NamingService.FromContent(viewContent));
                    WriteJavascriptFile(context, viewPath, javascriptContent);

                    File.WriteAllText(tempViewPath, javascriptContent);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private string GetTempJavascriptFilePath(JavascriptViewGeneratorConfiguration configuration, string viewPath)
        {
            return Path.Combine(configuration.TempDirectory, HashHelper.Sha1(viewPath) + ".js");
        }

        private void WriteJavascriptFile(HttpContext context, string path, string content)
        {
            context.Response.Write("/*" + path + "*/");
            context.Response.Write(Environment.NewLine);
            context.Response.Write(content);
            context.Response.Write(Environment.NewLine);
        }
    }
}

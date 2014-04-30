using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Hosting.Integration
{
    public class ErrorHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            Exception exception = context.Server.GetLastError();
            if (exception == null)
            {
                context.Response.Write("No error!");
                return;
            }

            CodeDomViewServiceException viewServiceException = exception as CodeDomViewServiceException;
            if (viewServiceException == null)
            {
                context.Response.Write(exception.Message);
                context.Response.Write("<hr />");
                context.Response.Write(exception.StackTrace);
            }


            context.Response.Write(viewServiceException.ViewContent);
            context.Response.Write("<hr />");
            context.Response.Write(viewServiceException.SourceCode);
        }
    }
}

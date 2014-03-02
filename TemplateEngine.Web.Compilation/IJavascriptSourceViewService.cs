using Neptuo.Templates.Compilation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Compilation
{
    public interface IJavascriptSourceViewService
    {
        INamingService NamingService { get; }
        string GenerateJavascript(string viewContent, IViewServiceContext context, INaming naming, string optionalViewPath);
    }
}

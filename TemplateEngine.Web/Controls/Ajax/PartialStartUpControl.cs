using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class PartialStartUpControl : IControl
    {
        private HttpContextBase httpContext;

        public string DefaultUpdate { get; set; }

        public PartialStartUpControl(HttpContextBase httpContext)
        {
            Guard.NotNull(httpContext, "httpContext");
            this.httpContext = httpContext;
        }

        public void OnInit()
        {
            Guard.NotNull(DefaultUpdate, "DefaultUpdate");
        }

        public void Render(IHtmlWriter writer)
        {
            string toUpdate = String.Join(",", DefaultUpdate.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(s => "'" + s + "'"));

            string startupStript = String.Format(
                "JsRuntime.Start(); Neptuo.TemplateEngine.Web.Application.Start(\"{0}\", [{1}]);", 
                httpContext.Request.ApplicationPath, 
                toUpdate
            );

            writer
                .Tag("script")
                .Content(startupStript)
                .CloseFullTag();
        }
    }
}

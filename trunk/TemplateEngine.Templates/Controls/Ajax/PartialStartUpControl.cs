using Neptuo.TemplateEngine.Configuration;
using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class PartialStartUpControl : IControl
    {
        private IApplicationConfiguration config;
        private HttpContextBase httpContext;

        public string DefaultUpdate { get; set; }

        public PartialStartUpControl(IApplicationConfiguration config, HttpContextBase httpContext)
        {
            Guard.NotNull(config, "config");
            Guard.NotNull(httpContext, "httpContext");
            this.config = config;
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
                "JsRuntime.Start(); Neptuo.TemplateEngine.Web.Application.Start({0}, \"{1}\", [{2}], \"{3}\");", 
                config.IsDebug ? "true" : "false",
                httpContext.Request.ApplicationPath, 
                toUpdate,
                ".html"
            );

            writer
                .Tag("script")
                .Content(startupStript)
                .CloseFullTag();
        }
    }
}

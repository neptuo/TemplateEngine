using Neptuo.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace Neptuo.TemplateEngine.Backend
{
    public class JavascriptBootstrapTask : IBootstrapTask
    {
        public BundleCollection bundles;

        public JavascriptBootstrapTask()
        {
            bundles = BundleTable.Bundles;
        }

        public void Initialize()
        {
            bundles.Add(new ScriptBundle("~/design/js/admin")
                .Include("~/Design/Scripts/jquery-{version}.js")
                .Include("~/Design/Scripts/bootstrap.js")
                .IncludeDirectory("~/Design/Scripts/Generated", "*.js", true)
            );

            bundles.Add(new StyleBundle("~/design/css/admin")
                .Include("~/Design/Styles/bootstrap.css")
                .Include("~/Design/Styles/bootstrap-theme.css")
                .IncludeDirectory("~/Design/Styles/My", "*.css")
            );
        }
    }
}

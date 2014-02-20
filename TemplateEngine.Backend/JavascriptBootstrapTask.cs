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
            bundles.Add(new ScriptBundle("~/dynamic")
                .IncludeDirectory("~/Design/Scripts/Generated", "*.js", true)
            );
        }
    }
}

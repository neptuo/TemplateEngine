using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Hosting.Integration;
using Neptuo.TemplateEngine.Publishing.Hosting.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Security;
using System.Web.SessionState;

namespace Neptuo.TemplateEngine.Blog.UI
{
    public class Global : HostedApplication
    {
        public Global()
            : base(new ApplicationBuilder())
        { }
    }

    public class ApplicationBuilder : ApplicationBuilderBase
    {
        public override void RegisterBootstrapTasks(IBootstrapTaskRegistry bootstrapper)
        {
            bootstrapper.Register<JavascriptBootstrapTask>();
            bootstrapper.Register<PublishingBootstrapTask>();
        }
    }

    public class JavascriptBootstrapTask : IBootstrapTask
    {
        public BundleCollection bundles;

        public JavascriptBootstrapTask()
        {
            bundles = BundleTable.Bundles;
        }

        public void Initialize()
        {
            bundles.Add(new ScriptBundle("~/design/js/blog")
                .Include("~/Design/Scripts/jquery-{version}.js")
                .Include("~/Design/Scripts/bootstrap.js")
                .IncludeDirectory("~/Design/Scripts/Generated", "*.js")
                .IncludeDirectory("~/Design/Scripts/Generated/TemplateEngine", "*.js", true)
            );

            bundles.Add(new StyleBundle("~/design/css/blog")
                .Include("~/Design/Styles/bootstrap.css")
                .Include("~/Design/Styles/bootstrap-theme.css")
                .IncludeDirectory("~/Design/Styles/My", "*.css")
            );
        }
    }
}
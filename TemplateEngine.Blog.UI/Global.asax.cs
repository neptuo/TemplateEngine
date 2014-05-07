using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Hosting.Integration;
using Neptuo.TemplateEngine.Publishing.Hosting.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            bootstrapper.Register<PublishingBootstrapTask>();
        }
    }
}
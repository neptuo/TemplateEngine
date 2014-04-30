using System.Web.Optimization;
using Neptuo.Bootstrap;
using Neptuo.Data;
using Neptuo.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Hosting.Bootstrap;
using Neptuo.TemplateEngine.Hosting.Integration;
using Neptuo.Web;

namespace Neptuo.TemplateEngine.Backend.UI
{
    public class Global : HostedApplication
    {
        public Global()
            : base(new BackendBuilder())
        { }

        class BackendBuilder : IApplicationBuilder
        {
            public void RegisterTypes(IDependencyContainer dependencyContainer)
            {
                //TODO: Move to accounts
                dependencyContainer
                    .RegisterType<IUnitOfWorkFactory, DbContextUnitOfWorkFactory<DataContext>>(new PerRequestLifetime());
            }

            public void RegisterBootstrapTasks(IBootstrapTaskRegistry bootstrapper)
            {
                bootstrapper.Register<JavascriptBootstrapTask>();

                //TODO: Bootstrap as independent module
                bootstrapper.Register<AccountBootstrapTask>();
            }
        }

        class JavascriptBootstrapTask : IBootstrapTask
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
}
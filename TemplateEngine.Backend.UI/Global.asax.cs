using System.Web.Optimization;
using Neptuo.Bootstrap;
using Neptuo.Data;
using Neptuo.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Data.Entity;
using Neptuo.TemplateEngine.Accounts.Hosting.Bootstrap;
using Neptuo.TemplateEngine.Hosting.Integration;
using Neptuo.Web;
using Neptuo.TemplateEngine.Publishing.Hosting.Bootstrap;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Providers;
using System;
using Neptuo.TemplateEngine.Navigation;

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
                bootstrapper.Register<PublishingBootstrapTask>();
            }

            public void RegisterForms(IFormUriRegistry formRegistry, ITemplateUrlFormatter formatter)
            {
                formRegistry
                    .Register("Home", formatter.FormatUrl("~/Default"));

                formRegistry
                    .Register("Accounts.Login", formatter.FormatUrl("~/Accounts/Login"))
                    .Register("Accounts.User.List", formatter.FormatUrl("~/Accounts/UserList"))
                    .Register("Accounts.User.Edit", formatter.FormatUrl("~/Accounts/UserEdit"))
                    .Register("Accounts.Role.List", formatter.FormatUrl("~/Accounts/RoleList"))
                    .Register("Accounts.Role.Edit", formatter.FormatUrl("~/Accounts/RoleEdit"))
                    .Register("Accounts.Log.List", formatter.FormatUrl("~/Accounts/LogList"))
                    .Register("Accounts.Permission.List", formatter.FormatUrl("~/Accounts/PermissionList"));

                formRegistry
                    .Register("Publishing.Article.List", formatter.FormatUrl("~/Publishing/ArticleList"))
                    .Register("Publishing.Article.Edit", formatter.FormatUrl("~/Publishing/ArticleEdit"))
                    .Register("Publishing.ArticleLine.List", formatter.FormatUrl("~/Publishing/ArticleLineList"))
                    .Register("Publishing.ArticleLine.Edit", formatter.FormatUrl("~/Publishing/ArticleLineEdit"))
                    .Register("Publishing.ArticleTag.List", formatter.FormatUrl("~/Publishing/ArticleTagList"))
                    .Register("Publishing.ArticleTag.Edit", formatter.FormatUrl("~/Publishing/ArticleTagEdit"));
            }

            public void RegisterGlobalNavigations(GlobalNavigationCollection globalNavigations)
            {
                globalNavigations
                    .Add("Accounts.User.Deleted", (FormUri)"Accounts.User.List")
                    .Add("Accounts.User.Created", (FormUri)"Accounts.User.List")
                    .Add("Accounts.User.Updated", (FormUri)"Accounts.User.List")
                    .Add("Accounts.Role.Deleted", (FormUri)"Accounts.Role.List")
                    .Add("Accounts.Role.Created", (FormUri)"Accounts.Role.List")
                    .Add("Accounts.Role.Updated", (FormUri)"Accounts.Role.List")
                    .Add("Accounts.Permission.Updated", (FormUri)"Accounts.Role.List")
                    .Add("Accounts.LoggedIn", (FormUri)"Home")
                    .Add("Accounts.LoggedOut", (FormUri)"Accounts.Login");

                globalNavigations
                    .Add("Publishing.Article.Deleted", (FormUri)"Publishing.Article.List")
                    .Add("Publishing.Article.Created", (FormUri)"Publishing.Article.List")
                    .Add("Publishing.Article.Updated", (FormUri)"Publishing.Article.List")
                    .Add("Publishing.ArticleLine.Deleted", (FormUri)"Publishing.ArticleLine.List")
                    .Add("Publishing.ArticleLine.Created", (FormUri)"Publishing.ArticleLine.List")
                    .Add("Publishing.ArticleLine.Updated", (FormUri)"Publishing.ArticleLine.List")
                    .Add("Publishing.ArticleTag.Deleted", (FormUri)"Publishing.ArticleTag.List")
                    .Add("Publishing.ArticleTag.Created", (FormUri)"Publishing.ArticleTag.List")
                    .Add("Publishing.ArticleTag.Updated", (FormUri)"Publishing.ArticleTag.List");
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
using Neptuo.Bootstrap;
using Neptuo.Events;
using Neptuo.TemplateEngine.Controllers;
using Neptuo.TemplateEngine.Hosting.DataSources;
using Neptuo.TemplateEngine.Navigation.Bootstrap;
using Neptuo.TemplateEngine.Providers;
using Neptuo.TemplateEngine.Publishing.Controllers;
using Neptuo.TemplateEngine.Publishing.Controllers.Commands;
using Neptuo.TemplateEngine.Publishing.Controllers.Validation;
using Neptuo.TemplateEngine.Publishing.Data;
using Neptuo.TemplateEngine.Publishing.Data.Entity;
using Neptuo.TemplateEngine.Publishing.Data.Entity.Queries;
using Neptuo.TemplateEngine.Publishing.Data.Queries;
using Neptuo.TemplateEngine.Publishing.Templates.DataSources;
using Neptuo.TemplateEngine.Templates.Compilation.Parsers;
using Neptuo.TemplateEngine.Web.ViewBundles;
using Neptuo.Templates.Compilation;
using Neptuo.Templates.Compilation.Parsers;
using Neptuo.Validation;
using Neptuo.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Publishing.Hosting.Bootstrap
{
    [Module]
    public class PublishingBootstrapTask : IBootstrapTask
    {
        private IDependencyContainer dependencyContainer;
        private TypeBuilderRegistry registry;
        private IControllerRegistry controllerRegistry;
        private IWebDataSourceRegistry dataSourceRegistry;
        private IEventRegistry eventRegistry;

        public PublishingBootstrapTask(IDependencyContainer dependencyContainer, TypeBuilderRegistry registry, IControllerRegistry controllerRegistry, IWebDataSourceRegistry dataSourceRegistry, IEventRegistry eventRegistry)
        {
            Guard.NotNull(dependencyContainer, "dependencyContainer");
            Guard.NotNull(registry, "registry");
            Guard.NotNull(controllerRegistry, "controllerRegistry");
            Guard.NotNull(dataSourceRegistry, "dataSourceRegistry");
            Guard.NotNull(eventRegistry, "eventRegistry");

            this.dependencyContainer = dependencyContainer;
            this.registry = registry;
            this.controllerRegistry = controllerRegistry;
            this.dataSourceRegistry = dataSourceRegistry;
            this.eventRegistry = eventRegistry;
        }

        public void Initialize()
        {
            SetupDependencyContainer(dependencyContainer);
            SetupTypeBuilderRegistry(registry);
            SetupControllers(controllerRegistry);
            SetupDataSources(dataSourceRegistry);

            SetupEvents(eventRegistry);

            DataContext dbContext = new DataContext();
            dbContext.SaveChanges();
        }

        protected void SetupTypeBuilderRegistry(TypeBuilderRegistry registry)
        {
            registry.RegisterNamespace(new NamespaceDeclaration("data", "Neptuo.TemplateEngine.Publishing.Templates.DataSources, Neptuo.TemplateEngine.Publishing.Templates"));

            registry.RegisterComponentBuilder("ui", "PublishingSideNav", new UserTemplateComponentBuilderFactory("~/Views/Publishing/SideNavUserControl.view"));
        }

        protected void SetupDependencyContainer(IDependencyContainer dependencyContainer)
        {
            dependencyContainer
                .RegisterType<DataContext>(new PerRequestLifetime())

                .RegisterType<IArticleRepository, EntityArticleRepository>(new PerRequestLifetime())
                .RegisterType<IArticleQuery, EntityArticleQuery>()
                .RegisterType<IActivator<Article>, EntityArticleRepository>(new PerRequestLifetime())
                .RegisterActivator<IArticleQuery>(new PerRequestLifetime())
                .RegisterType<IValidator<ArticleCreateCommand>, ArticleValidator>()
                .RegisterType<IValidator<ArticleEditCommand>, ArticleValidator>()

                .RegisterType<IArticleLineRepository, EntityArticleLineRepository>(new PerRequestLifetime())
                .RegisterType<IArticleLineQuery, EntityArticleLineQuery>()
                .RegisterType<IActivator<ArticleLine>, EntityArticleLineRepository>(new PerRequestLifetime())
                .RegisterActivator<IArticleLineQuery>(new PerRequestLifetime())
                .RegisterType<IValidator<ArticleLineCreateCommand>, ArticleLineValidator>()
                .RegisterType<IValidator<ArticleLineEditCommand>, ArticleLineValidator>()

                .RegisterType<IArticleTagRepository, EntityArticleTagRepository>(new PerRequestLifetime())
                .RegisterType<IArticleTagQuery, EntityArticleTagQuery>()
                .RegisterType<IActivator<ArticleTag>, EntityArticleTagRepository>(new PerRequestLifetime())
                .RegisterActivator<IArticleTagQuery>(new PerRequestLifetime())
                .RegisterType<IValidator<ArticleTagCreateCommand>, ArticleTagValidator>()
                .RegisterType<IValidator<ArticleTagEditCommand>, ArticleTagValidator>()

                ;
        }

        protected void SetupControllers(IControllerRegistry controllerRegistry)
        {
            controllerRegistry
                .Add(dependencyContainer, typeof(ArticleController))
                .Add(dependencyContainer, typeof(ArticleLineController))
                .Add(dependencyContainer, typeof(ArticleTagController));
        }

        protected void SetupDataSources(IWebDataSourceRegistry dataSourceRegistry)
        {
            dataSourceRegistry.AddFromAssembly(typeof(ArticleDataSource).Assembly);
        }

        protected void SetupEvents(IEventRegistry eventRegistry)
        {
        }

    }
}

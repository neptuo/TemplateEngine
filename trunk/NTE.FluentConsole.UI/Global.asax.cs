using Neptuo.Bootstrap;
using Neptuo.FileSystems;
using Neptuo.TemplateEngine.Hosting.Integration;
using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using Neptuo.Templates.Compilation.Parsers;
using Neptuo.Web.Resources;
using Neptuo.Web.Resources.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Neptuo.TemplateEngine.FluentConsole.UI
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
            base.RegisterBootstrapTasks(bootstrapper);

            bootstrapper.Register<ResourcesBootstrapTask>();
        }
    }

    public class ResourcesBootstrapTask : IBootstrapTask
    {
        private IDependencyContainer dependencyContainer;
        private TypeBuilderRegistry registry;

        public ResourcesBootstrapTask(IDependencyContainer dependencyContainer, TypeBuilderRegistry registry)
        {
            Guard.NotNull(dependencyContainer, "dependencyContainer");
            Guard.NotNull(registry, "registry");
            this.dependencyContainer = dependencyContainer;
            this.registry = registry;
        }

        public void Initialize()
        {
            XmlReader.LoadFromXml(ResourceTable.Resources, new StaticFile(dependencyContainer.Resolve<IVirtualPathProvider>().MapPath("~/Resources.xml")));
            dependencyContainer.RegisterInstance<IResourceCollection>(ResourceTable.Resources);

            registry.RegisterNamespace(new NamespaceDeclaration("ui", "Neptuo.TemplateEngine.FluentConsole.UI.Controls, Neptuo.TemplateEngine.FluentConsole.UI"));
        }
    }
}
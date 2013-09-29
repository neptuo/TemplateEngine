using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using Neptuo.Templates.Compilation.CodeGenerators;
using Neptuo.Templates.Compilation.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Backend
{
    public class ViewServiceBootstrapTask : IBootstrapTask
    {
        private IDependencyContainer container;
        private HttpContextBase httpContext;

        public ViewServiceBootstrapTask(IDependencyContainer container, HttpContextBase httpContext)
        {
            this.container = container;
            this.httpContext = httpContext;
        }

        public void Initialize()
        {
            IVirtualPathProvider virtualPathProvider = new ServerVirtualPathProvider();
            IFileProvider fileProvider = new FileProvider(virtualPathProvider);
            
            container
                .RegisterInstance<IVirtualPathProvider>(virtualPathProvider)
                .RegisterInstance<IFileProvider>(fileProvider);

            TypeBuilderRegistry registry = new TypeBuilderRegistry(
                new TypeBuilderRegistryConfiguration(container),
                new LiteralControlBuilder<LiteralControl>(c => c.Text),
                new GenericContentControlBuilder<GenericContentControl>(c => c.TagName)
            );
            SetupTypeBuilderRegistry(registry);

            CodeDomViewService viewService = new CodeDomViewService();
            SetupViewService(viewService, registry, fileProvider, virtualPathProvider);

            container
                .RegisterInstance<IViewService>(viewService);
        }

        protected virtual void SetupViewService(CodeDomViewService viewService, TypeBuilderRegistry registry, IFileProvider fileProvider, IVirtualPathProvider virtualPathProvider)
        {
            viewService.ParserService.ContentParsers.Add(new XmlContentParser(registry));
            viewService.ParserService.DefaultValueParser = new PlainValueParser();
            viewService.ParserService.ValueParsers.Add(new MarkupExtensionValueParser(registry));
            viewService.NamingService = new HashNamingService(fileProvider);
            viewService.TempDirectory = @"C:\Temp\NeptuoTemplateEngine";
            viewService.BinDirectories.Add(virtualPathProvider.MapPath("~/Bin"));

            CODEDOMREGISTEREXTENSIONS.Register(viewService.CodeDomGenerator);
        }

        protected virtual void SetupTypeBuilderRegistry(TypeBuilderRegistry registry)
        {
            registry.RegisterNamespace(new NamespaceDeclaration("ui", "Neptuo.TemplateEngine.Web.Controls, Neptuo.TemplateEngine.Web"));
        }
    }
}

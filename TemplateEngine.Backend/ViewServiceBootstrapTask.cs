using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Backend.Web;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Compilation.CodeGenerators;
using Neptuo.TemplateEngine.Web.Compilation.CodeObjects;
using Neptuo.TemplateEngine.Web.Compilation.Parsers;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.TemplateEngine.Web.Observers;
using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using Neptuo.Templates.Compilation.CodeGenerators;
using Neptuo.Templates.Compilation.Parsers;
using Neptuo.Web;
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
                .RegisterInstance<TypeBuilderRegistry>(registry)
                .RegisterInstance<IViewService>(viewService)
                .RegisterType<IStackStorage<IViewStorage>, StackStorage<IViewStorage>>(new PerRequestLifetime())
                .RegisterType<IEventHandler, SimpleEventHandler>(new PerRequestLifetime());
        }

        protected virtual void SetupViewService(CodeDomViewService viewService, TypeBuilderRegistry registry, IFileProvider fileProvider, IVirtualPathProvider virtualPathProvider)
        {
            viewService.ParserService.ContentParsers.Add(new XmlContentParser(registry));
            viewService.ParserService.DefaultValueParser = new PlainValueParser();
            viewService.ParserService.ValueParsers.Add(new MarkupExtensionValueParser(registry));
            viewService.NamingService = new HashNamingService(fileProvider);
            viewService.TempDirectory = @"C:\Temp\NeptuoTemplateEngine";
            //viewService.DebugMode = true;
            viewService.BinDirectories.Add(virtualPathProvider.MapPath("~/Bin"));
            SetupCodeDomGenerator(viewService.CodeDomGenerator);
        }

        protected virtual void SetupTypeBuilderRegistry(TypeBuilderRegistry registry)
        {
            registry.RegisterNamespace(new NamespaceDeclaration("ui", "Neptuo.TemplateEngine.Web.Controls, Neptuo.TemplateEngine.Web"));
            registry.RegisterObserverBuilder("ui", "Event", new DefaultTypeObserverBuilderFactory(typeof(EventObserver), ObserverBuilderScope.PerElement));
            registry.RegisterObserverBuilder("view", "ID", new DefaultTypeObserverBuilderFactory(typeof(ViewIdentifierObserver), ObserverBuilderScope.PerElement));
            registry.RegisterObserverBuilder("html", "*", new DefaultTypeObserverBuilderFactory(typeof(HtmlObserver), ObserverBuilderScope.PerElement));
            
            registry.RegisterPropertyBuilder(typeof(ITemplate), new DefaultPropertyBuilderFactory<TemplatePropertyBuilder>());
        }

        protected virtual void SetupCodeDomGenerator(CodeDomGenerator generator)
        {
            IFieldNameProvider fieldNameProvider = new SequenceFieldNameProvider();
            generator.RegisterStandartCodeGenerators(fieldNameProvider);
            generator.SetCodeObjectGenerator(typeof(TemplateCodeObject), new CodeDomTemplateGenerator(fieldNameProvider));
            generator.SetCodeObjectGenerator(typeof(MethodReferenceCodeObject), new CodeDomMethodReferenceGenerator());
        }
    }
}

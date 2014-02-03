using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Backend.Web;
using Neptuo.TemplateEngine.PresentationModels;
using Neptuo.TemplateEngine.PresentationModels.Observers;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Web.Compilation;
using Neptuo.TemplateEngine.Web.Compilation.CodeGenerators;
using Neptuo.TemplateEngine.Web.Compilation.CodeObjects;
using Neptuo.TemplateEngine.Web.Compilation.Parsers;
using Neptuo.TemplateEngine.Web.Compilation.PreProcessing;
using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.TemplateEngine.Web.Observers;
using Neptuo.Templates;
using Neptuo.Templates.Compilation;
using Neptuo.Templates.Compilation.CodeGenerators;
using Neptuo.Templates.Compilation.Parsers;
using Neptuo.Templates.Compilation.PreProcessing;
using Neptuo.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CodeDomStructureGenerator = Neptuo.TemplateEngine.Web.Compilation.CodeGenerators.CodeDomStructureGenerator;

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
                new TypeBuilderRegistryConfiguration(container).AddComponentSuffix("presenter"),
                new LiteralControlBuilder<LiteralControl>(c => c.Text),
                new GenericContentControlBuilder<GenericContentControl>(c => c.TagName)
            );
            SetupTypeBuilderRegistry(registry);

            ExtendedViewService viewService = new ExtendedViewService();
            SetupViewService(viewService, registry, fileProvider, virtualPathProvider);

            container
                .RegisterInstance<TypeBuilderRegistry>(registry)
                .RegisterInstance<IViewService>(viewService)
                .RegisterInstance<IJavascriptSourceViewService>(viewService)
                .RegisterInstance<IVirtualUrlProvider>(new ServerVirtualPathProvider())
                .RegisterInstance<ICurrentUrlProvider>(new ServerVirtualPathProvider())
                .RegisterType<IParameterProviderFactory, RequestParameterProviderFactory>(new PerRequestLifetime())
                .RegisterType<IStackStorage<IViewStorage>, StackStorage<IViewStorage>>(new PerRequestLifetime())
                .RegisterType<TemplateContentStorageStack>(new PerRequestLifetime())
                //.RegisterType<IEventHandler, SimpleEventHandler>(new PerRequestLifetime())
                .RegisterType<MessageStorage>(new PerSessionLifetime(1));
        }

        protected virtual void SetupViewService(CodeDomViewService viewService, TypeBuilderRegistry registry, IFileProvider fileProvider, IVirtualPathProvider virtualPathProvider)
        {
            string tempDirectory = @"C:\Temp\NeptuoTemplateEngine";
            string currentDirectory = DateTime.Now.Ticks.ToString();

            string currentTemp = Path.Combine(tempDirectory, currentDirectory);
            if (!Directory.Exists(currentTemp))
                Directory.CreateDirectory(currentTemp);

            viewService.ParserService.ContentParsers.Add(new XmlContentParser(registry));
            viewService.ParserService.DefaultValueParser = new PlainValueParser();
            viewService.ParserService.ValueParsers.Add(new MarkupExtensionValueParser(registry));
            viewService.NamingService = new HashNamingService(fileProvider);
            viewService.TempDirectory = currentTemp;
            viewService.DebugMode = CodeDomDebugMode.GeneratePdb | CodeDomDebugMode.GenerateSourceCode;
            viewService.BinDirectories.Add(virtualPathProvider.MapPath("~/Bin"));
            
            SetupCodeDomGenerator(viewService.CodeDomGenerator);
            SetupPreProcesssor(viewService.PreProcessorService, viewService);
        }

        protected virtual void SetupTypeBuilderRegistry(TypeBuilderRegistry registry)
        {
            registry.RegisterNamespace(new NamespaceDeclaration("ui", "Neptuo.TemplateEngine.Web.Controls, Neptuo.TemplateEngine.Web"));
            registry.RegisterNamespace(new NamespaceDeclaration("", "Neptuo.TemplateEngine.Web.Extensions, Neptuo.TemplateEngine.Web"));

            registry.RegisterComponentBuilder("ui", "AdminLayout", new UserTemplateComponentBuilderFactory("~/Views/Shared/AdminLayout.view"));
            registry.RegisterComponentBuilder("ui", "SubHeader", new UserTemplateComponentBuilderFactory("~/Views/Shared/SubHeader.view"));
            
            registry.RegisterObserverBuilder("ui", "Event", new DefaultTypeObserverBuilderFactory(typeof(EventObserver), ObserverBuilderScope.PerElement));
            registry.RegisterObserverBuilder("view", "ID", new DefaultTypeObserverBuilderFactory(typeof(ViewIdentifierObserver), ObserverBuilderScope.PerElement));
            registry.RegisterObserverBuilder("html", "*", new DefaultTypeObserverBuilderFactory(typeof(HtmlObserver), ObserverBuilderScope.PerElement));
            registry.RegisterObserverBuilder("l", "*", new LocalizationObserverBuilderFactory());
            registry.RegisterObserverBuilder("form", "*", new FormUriObserverBuiderFactory());
            registry.RegisterObserverBuilder("ui", "IsPlaceholder", new DefaultTypeObserverBuilderFactory(typeof(IsPlaceholderObserver), ObserverBuilderScope.PerElement));
            registry.RegisterObserverBuilder("ui", "IsVisible", new DefaultTypeObserverBuilderFactory(typeof(VisibleObserver), ObserverBuilderScope.PerElement));
            
            registry.RegisterPropertyBuilder(typeof(ITemplate), new DefaultPropertyBuilderFactory<TemplatePropertyBuilder>());
            registry.RegisterPropertyBuilder(typeof(CssClassCollection), new DefaultPropertyBuilderFactory<CssClassPropertyBuilder>());
        }

        protected virtual void SetupCodeDomGenerator(CodeDomGenerator generator)
        {
            IFieldNameProvider fieldNameProvider = new SequenceFieldNameProvider();
            generator.IsDirectObjectResolve = true;
            generator.RegisterStandartCodeGenerators(fieldNameProvider);
            generator.SetBaseStructureGenerator(new CodeDomStructureGenerator());

            generator.SetCodeObjectGenerator(typeof(TemplateCodeObject), new CodeDomTemplateGenerator(fieldNameProvider));
            generator.SetCodeObjectGenerator(typeof(MethodReferenceCodeObject), new CodeDomMethodReferenceGenerator());
            generator.SetCodeObjectGenerator(typeof(LocalizationCodeObject), new CodeDomLocalizationGenerator());
            generator.SetCodeObjectGenerator(typeof(ResolveUrlCodeObject), new CodeDomResolveUrlGenerator());
            generator.SetCodeObjectGenerator(typeof(ExplicitCastCodeObject), new CodeDomExplicitCastGenerator());

            generator.SetPropertyDescriptorGenerator(typeof(CssClassPropertyDescriptor), new CodeDomCssClassPropertyGenerator());
            generator.SetPropertyTypeGenerator(typeof(ITemplate), new CodeDomTemplatePropertyTypeGenerator(fieldNameProvider, "{0}.Views.{1}.view"));
            generator.SetAttributeGenerator(typeof(PropertySetAttribute), new CodeDomPropertySetAttributeGenerator());
        }

        protected virtual void SetupPreProcesssor(IPreProcessorService preprocessorService, CodeDomViewService viewService)
        {
            preprocessorService.AddVisitor(new TemplatePropertyVisitor("{0}.Views.{1}.view", viewService.ParserService));
        }
    }
}

using Neptuo.Bootstrap;
using Neptuo.TemplateEngine.Backend.Web;
using Neptuo.TemplateEngine.PresentationModels;
using Neptuo.TemplateEngine.PresentationModels.Observers;
using Neptuo.TemplateEngine.Templates;
using Neptuo.TemplateEngine.Web;
using Neptuo.TemplateEngine.Templates.Compilation;
using Neptuo.TemplateEngine.Templates.Compilation.CodeGenerators;
using Neptuo.TemplateEngine.Templates.Compilation.CodeObjects;
using Neptuo.TemplateEngine.Templates.Compilation.Parsers;
using Neptuo.TemplateEngine.Templates.Compilation.PreProcessing;
using Neptuo.TemplateEngine.Templates.Controls;
using Neptuo.TemplateEngine.Templates.Observers;
using Neptuo.TemplateEngine.Web.ViewBundles;
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
using CodeDomStructureGenerator = Neptuo.TemplateEngine.Templates.Compilation.CodeGenerators.CodeDomStructureGenerator;
using Neptuo.TemplateEngine.Providers;

namespace Neptuo.TemplateEngine.Backend.Bootstrap
{
    public class ViewServiceBootstrapTask : IBootstrapTask
    {
        private IDependencyContainer container;

        public ViewServiceBootstrapTask(IDependencyContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            IVirtualPathProvider virtualPathProvider = new ServerPathProvider();
            IFileProvider fileProvider = new FileProvider(virtualPathProvider);
            
            container
                .RegisterInstance<IVirtualPathProvider>(virtualPathProvider)
                .RegisterInstance<IFileProvider>(fileProvider);

            XmlViewBundleLoader loader = new XmlViewBundleLoader(virtualPathProvider);
            loader.LoadDirectory("~/Views", ViewBundleTable.Bundles);

            TypeBuilderRegistry registry = new TypeBuilderRegistry(
                new TypeBuilderRegistryConfiguration(container).AddComponentSuffix("presenter"),
                new LiteralControlBuilder<LiteralControl>(c => c.Text),
                new GenericContentControlBuilder<GenericContentControl>(c => c.TagName)
            );
            SetupTypeBuilderRegistry(registry);

            ViewService viewService = new ViewService();
            SetupViewService(viewService, registry, fileProvider, virtualPathProvider);

            container
                .RegisterInstance<TypeBuilderRegistry>(registry)
                .RegisterInstance<IViewService>(viewService)
                .RegisterInstance<ViewService>(viewService)
                .RegisterInstance<IVirtualUrlProvider>(new ServerPathProvider())
                .RegisterInstance<ICurrentUrlProvider>(new ServerPathProvider())
                .RegisterType<IParameterProviderFactory, RequestParameterProviderFactory>(new PerRequestLifetime())
                .RegisterType<IStackStorage<IViewStorage>, StackStorage<IViewStorage>>(new PerRequestLifetime())
                .RegisterType<IViewActivator, ViewServiceViewActivator>()
                .RegisterType<IRequestContext, CompositeRequestContext>()
                .RegisterType<TemplateContentStorageStack>(new PerRequestLifetime())
                //.RegisterType<IEventHandler, SimpleEventHandler>(new PerRequestLifetime())
                .RegisterType<MessageStorage>(new PerSessionLifetime(1));
        }

        protected virtual void SetupViewService(CodeDomViewService viewService, TypeBuilderRegistry registry, IFileProvider fileProvider, IVirtualPathProvider virtualPathProvider)
        {
            string tempDirectory = @"C:\Temp\NeptuoTemplateEngine";
            string currentDirectory = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");

#if DEBUG
            string currentTemp = Path.Combine(tempDirectory, currentDirectory);
            if (!Directory.Exists(currentTemp))
                Directory.CreateDirectory(currentTemp);
#else
            string currentTemp = tempDirectory;
#endif

            viewService.ParserService.ContentParsers.Add(new XmlContentParser(registry));
            viewService.ParserService.DefaultValueParser = new PlainValueParser();
            viewService.ParserService.ValueParsers.Add(new MarkupExtensionValueParser(registry));
            viewService.NamingService = new HashNamingService(fileProvider);
            viewService.TempDirectory = currentTemp;
            viewService.DebugMode = CodeDomDebugMode.GeneratePdb | CodeDomDebugMode.GenerateSourceCode;
            viewService.BinDirectories.Add(virtualPathProvider.MapPath("~/Bin"));
            
            SetupCodeDomGenerator(viewService.CodeDomGenerator);
            SetupJavascriptGenerator(viewService.JavascriptGenerator);
            SetupPreProcesssor(viewService.PreProcessorService, viewService);
        }

        protected virtual void SetupTypeBuilderRegistry(TypeBuilderRegistry registry)
        {
            registry.RegisterNamespace(new NamespaceDeclaration("ui", "Neptuo.TemplateEngine.Templates.Controls, Neptuo.TemplateEngine.Shared"));
            registry.RegisterNamespace(new NamespaceDeclaration("", "Neptuo.TemplateEngine.Templates.Extensions, Neptuo.TemplateEngine.Shared"));

            registry.RegisterNamespace(new NamespaceDeclaration("ui", "Neptuo.TemplateEngine.Templates.Controls, Neptuo.TemplateEngine.Templates"));
            registry.RegisterNamespace(new NamespaceDeclaration("", "Neptuo.TemplateEngine.Templates.Extensions, Neptuo.TemplateEngine.Templates"));
            registry.RegisterComponentBuilder("ajax", "View", new DefaultTypeComponentBuilderFactory(typeof(PartialViewControl)));
            registry.RegisterComponentBuilder("ajax", "StartUp", new DefaultTypeComponentBuilderFactory(typeof(PartialStartUpControl)));

            registry.RegisterComponentBuilder("ui", "AdminLayout", new UserTemplateComponentBuilderFactory("~/Views/Shared/AdminLayout.view"));
            registry.RegisterComponentBuilder("ui", "SubHeader", new UserTemplateComponentBuilderFactory("~/Views/Shared/SubHeader.view"));
            
            registry.RegisterObserverBuilder("ui", "Event", new DefaultTypeObserverBuilderFactory(typeof(EventObserver), ObserverBuilderScope.PerElement));
            registry.RegisterObserverBuilder("view", "ID", new DefaultTypeObserverBuilderFactory(typeof(ViewIdentifierObserver), ObserverBuilderScope.PerElement));
            registry.RegisterObserverBuilder("html", "*", new DefaultTypeObserverBuilderFactory(typeof(HtmlObserver), ObserverBuilderScope.PerElement));
            registry.RegisterObserverBuilder("l", "*", new LocalizationObserverBuilderFactory());
            registry.RegisterObserverBuilder("form", "*", new FormUriObserverBuiderFactory());
            registry.RegisterObserverBuilder("ui", "IsPlaceholder", new DefaultTypeObserverBuilderFactory(typeof(IsPlaceholderObserver), ObserverBuilderScope.PerElement));
            registry.RegisterObserverBuilder("ui", "IsVisible", new DefaultTypeObserverBuilderFactory(typeof(VisibleObserver), ObserverBuilderScope.PerElement));

            registry.RegisterObserverBuilder("ajax", "Update", new DefaultTypeObserverBuilderFactory(typeof(PartialObserver), ObserverBuilderScope.PerElement));

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
            //generator.SetPropertyTypeGenerator(typeof(ITemplate), new CodeDomTemplatePropertyTypeGenerator(fieldNameProvider, "{0}.Views.{1}.view"));
        }

        protected virtual void SetupJavascriptGenerator(SharpKitCodeGenerator generator)
        {
            generator.RunCsc = false;
        }

        protected virtual void SetupPreProcesssor(IPreProcessorService preprocessorService, CodeDomViewService viewService)
        {
            preprocessorService.AddVisitor(new TemplatePropertyVisitor("{0}.Views.{1}.view", viewService.ParserService));
        }
    }
}

using Neptuo.Bootstrap;
using Neptuo.Lifetimes;
using Neptuo.PresentationModels;
using Neptuo.PresentationModels.BindingConverters;
using Neptuo.PresentationModels.TypeModels;
using Neptuo.PresentationModels.Validation;
using Neptuo.TemplateEngine.Web.Controllers.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Bootstrap
{
    public class PresentationModelBootstrapTask : IBootstrapTask
    {
        protected IDependencyContainer DependencyContainer { get; private set; }

        public PresentationModelBootstrapTask(IDependencyContainer dependencyContainer)
        {
            DependencyContainer = dependencyContainer;
        }

        public void Initialize()
        {
            MetadataReaderService metadataReaders = new MetadataReaderService();
            SetupMetadataReaderService(metadataReaders);

            MetadataValidatorCollection validators = new MetadataValidatorCollection();
            SetupMetadataValidatorCollection(validators);

            BindingConverterCollection bindingConverters = new BindingConverterCollection();
            SetupBindingConverterCollection(bindingConverters);

            DependencyContainer
                .RegisterInstance(metadataReaders)
                .RegisterInstance(validators)
                .RegisterInstance<IMetadataValidatorCollection>(validators)
                .RegisterInstance(bindingConverters)
                .RegisterInstance<IBindingConverterCollection>(bindingConverters)
                .RegisterType<IModelBinder, ModelBinder>()
                .RegisterType<IModelDefinitionFactory, ReflectionModelDefinitionFactory>(new SingletonLifetime())
                .RegisterType<IModelValueProviderFactory, ReflectionModelValueProviderFactory>(new SingletonLifetime());
        }

        protected void SetupMetadataReaderService(MetadataReaderService readerService)
        {

        }

        protected void SetupMetadataValidatorCollection(MetadataValidatorCollection validators)
        {

        }

        protected void SetupBindingConverterCollection(BindingConverterCollection bindingConverters)
        {
            bindingConverters.AddStandart();
        }
    }
}

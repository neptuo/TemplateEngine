using Neptuo.PresentationModels;
using Neptuo.PresentationModels.TypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web
{
    public class PresentationConfiguration
    {
        public IModelDefinition ModelDefinition { get; protected set; }
        public IStackStorage<IViewStorage> ViewStorage { get; protected set; }
        public TemplateContentStorageStack TemplateStorage { get; protected set; }
        public IModelValueProviderFactory ValueProviderFactory { get; protected set; }

        public PresentationConfiguration(
            IModelDefinition modelDefinition, 
            IStackStorage<IViewStorage> viewStorage, 
            TemplateContentStorageStack templateStorage, 
            IModelValueProviderFactory valueProviderFactory)
        {
            if (modelDefinition == null)
                throw new ArgumentNullException("modelDefinition");

            if (viewStorage == null)
                throw new ArgumentNullException("viewStorage");

            if (templateStorage == null)
                throw new ArgumentNullException("templateStorage");

            if (valueProviderFactory == null)
                throw new ArgumentNullException("valueProviderFactory");

            ModelDefinition = modelDefinition;
            ViewStorage = viewStorage;
            TemplateStorage = templateStorage;
            ValueProviderFactory = valueProviderFactory;
        }
    }

    public class PresentationConfiguration<T> : PresentationConfiguration
    {
        public PresentationConfiguration(
            IModelDefinitionFactory factory, 
            IStackStorage<IViewStorage> viewStorage, 
            TemplateContentStorageStack templateStorage,
            IModelValueProviderFactory valueProviderFactory)
            : base(factory.Create<T>(), viewStorage, templateStorage, valueProviderFactory)
        { }
    }
}

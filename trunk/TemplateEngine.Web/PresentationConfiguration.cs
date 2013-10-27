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
        public IStackStorage<TemplateContentStorage> TemplateStorage { get; protected set; }

        public PresentationConfiguration(IModelDefinition modelDefinition, IStackStorage<IViewStorage> viewStorage, IStackStorage<TemplateContentStorage> templateStorage)
        {
            if (modelDefinition == null)
                throw new ArgumentNullException("modelDefinition");

            if (viewStorage == null)
                throw new ArgumentNullException("viewStorage");

            if (templateStorage == null)
                throw new ArgumentNullException("templateStorage");

            ModelDefinition = modelDefinition;
            ViewStorage = viewStorage;
            TemplateStorage = templateStorage;
        }
    }

    public class PresentationConfiguration<T> : PresentationConfiguration
    {
        public PresentationConfiguration(MetadataReaderService metadataReaderService, IStackStorage<IViewStorage> viewStorage, IStackStorage<TemplateContentStorage> templateStorage)
            : base(new ReflectionModelDefinitionBuilder(typeof(T), metadataReaderService).Build(), viewStorage, templateStorage)
        { }
    }
}

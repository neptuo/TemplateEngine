using Neptuo.PresentationModels;
using Neptuo.PresentationModels.TypeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web.Controllers.Binders
{
    public class ModelBinder : IModelBinder
    {
        protected IParameterProvider ParameterProvider { get; private set; }
        protected IModelDefinitionFactory ModelFactory { get; private set; }
        protected IModelValueProviderFactory ValueProviderFactory { get; private set; }
        protected IBindingConverterCollection BindingConverters { get; private set; }
        protected IDependencyContainer DependencyContainer { get; private set; }

        public ModelBinder(
            IParameterProvider parameterProvider, 
            IModelDefinitionFactory modelFactory, 
            IModelValueProviderFactory valueProviderFactory, 
            IBindingConverterCollection bindingConverters, 
            IDependencyContainer dependencyContainer)
        {
            ParameterProvider = parameterProvider;
            ModelFactory = modelFactory;
            ValueProviderFactory = valueProviderFactory;
            BindingConverters = bindingConverters;
            DependencyContainer = dependencyContainer;
        }

        public object Bind(Type targetType)
        {
            if (targetType == null)
                throw new ArgumentNullException("targetType");

            object instance = DependencyContainer.Resolve(targetType, null);
            return Bind(instance);
        }

        public object Bind(object instance)
        {
            if (instance == null)
                throw new ArgumentNullException("instance");

            IModelDefinition modelDefinition = ModelFactory.Create(instance.GetType());
            IBindingModelValueStorage storage = new BindingValueStorage(ParameterProvider);
            CopyModelValueProvider copyProvider = new CopyModelValueProvider(modelDefinition);
            IModelValueSetter model = ValueProviderFactory.Create(instance);

            copyProvider.Update(model, new BindingModelValueGetter(storage, BindingConverters, modelDefinition));
            return instance;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    public class ModelControllerFactory : IControllerFactory
    {
        protected IDependencyProvider DependencyProvider { get; private set; }
        protected Type ModelType { get; private set; }

        public ModelControllerFactory(IDependencyProvider dependencyProvider, Type modelType)
        {
            Guard.NotNull(dependencyProvider, "dependencyProvider");
            Guard.NotNull(modelType, "modelType");
            DependencyProvider = dependencyProvider;
            ModelType = modelType;
        }

        public IController Create()
        {
            return (IController)DependencyProvider.Resolve(typeof(CommandHandlerControllerFactory<>).MakeGenericType(ModelType));
        }
    }

    public class ModelControllerFactory<TModel> : IControllerFactory
    {
        protected IDependencyProvider DependencyProvider { get; private set; }

        public ModelControllerFactory(IDependencyProvider dependencyProvider)
        {
            DependencyProvider = dependencyProvider;
        }

        public IController Create()
        {
            return new CommandHandlerControllerFactory<TModel>(DependencyProvider);
        }
    }
}

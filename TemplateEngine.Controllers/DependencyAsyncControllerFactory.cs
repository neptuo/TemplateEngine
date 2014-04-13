using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public class DependencyAsyncControllerFactory : IAsyncControllerFactory
    {
        protected IDependencyContainer DependencyContainer { get; private set; }
        protected Type HandlerType { get; private set; }

        public DependencyAsyncControllerFactory(IDependencyContainer dependencyContainer, Type handlerType)
        {
            Guard.NotNull(dependencyContainer, "dependencyContainer");
            Guard.NotNull(handlerType, "handlerType");
            DependencyContainer = dependencyContainer;
            HandlerType = handlerType;
        }

        public IAsyncController Create()
        {
            return (IAsyncController)DependencyContainer.Resolve(HandlerType, null);
        }
    }
}

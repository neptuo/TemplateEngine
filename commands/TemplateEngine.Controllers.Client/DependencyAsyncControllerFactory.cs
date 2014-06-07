using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public class DependencyAsyncControllerFactory : IAsyncControllerFactory
    {
        protected IDependencyProvider DependencyProvider { get; private set; }
        protected Type HandlerType { get; private set; }

        public DependencyAsyncControllerFactory(IDependencyProvider dependencyProvider, Type handlerType)
        {
            Guard.NotNull(dependencyProvider, "dependencyContainer");
            Guard.NotNull(handlerType, "handlerType");
            DependencyProvider = dependencyProvider;
            HandlerType = handlerType;
        }

        public IAsyncController Create()
        {
            return (IAsyncController)DependencyProvider.Resolve(HandlerType, null);
        }
    }
}

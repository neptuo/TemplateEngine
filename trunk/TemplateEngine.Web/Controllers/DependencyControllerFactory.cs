using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    public class DependencyControllerFactory : IControllerFactory
    {
        protected IDependencyContainer DependencyContainer { get; private set; }
        protected Type HandlerType { get; private set; }

        public DependencyControllerFactory(IDependencyContainer dependencyContainer, Type handlerType)
        {
            Guard.NotNull(dependencyContainer, "dependencyContainer");
            Guard.NotNull(handlerType, "handlerType");
            DependencyContainer = dependencyContainer;
            HandlerType = handlerType;
        }

        public IController Create()
        {
            return (IController)DependencyContainer.Resolve(HandlerType, null);
        }
    }
}

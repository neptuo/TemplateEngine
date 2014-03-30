using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    public class DependencyControllerFactory : IControllerFactory
    {
        protected IDependencyProvider DependencyProvider { get; private set; }
        protected Type HandlerType { get; private set; }

        public DependencyControllerFactory(IDependencyProvider dependencyProvider, Type handlerType)
        {
            Guard.NotNull(dependencyProvider, "dependencyContainer");
            Guard.NotNull(handlerType, "handlerType");
            DependencyProvider = dependencyProvider;
            HandlerType = handlerType;
        }

        public IController Create()
        {
            return (IController)DependencyProvider.Resolve(HandlerType, null);
        }
    }
}

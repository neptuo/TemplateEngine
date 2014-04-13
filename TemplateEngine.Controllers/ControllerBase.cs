using Neptuo.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    public class ControllerBase : IController
    {
        protected IControllerContext Context { get; private set; }

        public void Execute(IControllerContext context)
        {
            Guard.NotNull(context, "context");
            Context = context;

            Type type = GetType();
            foreach (MethodInfo methodInfo in type.GetMethods())
            {
                ActionAttribute action = ReflectionHelper.GetAttribute<ActionAttribute>(methodInfo);
                if (action != null)
                {
                    if (action.ActionName == context.ActionName)
                    {
                        methodInfo.Invoke(this, null);
                        break;
                    }
                }
            }
        }
    }
}

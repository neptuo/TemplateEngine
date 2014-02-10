using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controllers
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ActionAttribute : Attribute
    {
        public string ActionName { get; private set; }

        public ActionAttribute(string actionName)
        {
            Guard.NotNull(actionName, "actionName");
            ActionName = actionName;
        }
    }
}

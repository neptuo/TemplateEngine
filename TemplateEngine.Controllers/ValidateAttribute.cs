using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ValidateAttribute : Attribute
    {
        public string MessageKey { get; private set; }

        public ValidateAttribute(string messageKey)
        {
            MessageKey = messageKey;
        }
    }
}

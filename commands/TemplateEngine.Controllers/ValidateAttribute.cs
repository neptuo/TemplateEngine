using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Controllers
{
    /// <summary>
    /// Defines validation request.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ValidateAttribute : Attribute
    {
        /// <summary>
        /// Validation messages key name.
        /// </summary>
        public string MessageKey { get; private set; }

        public ValidateAttribute(string messageKey)
        {
            MessageKey = messageKey;
        }
    }
}

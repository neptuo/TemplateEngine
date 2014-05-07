using Neptuo.ComponentModel;
using Neptuo.Templates.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Templates.Extensions
{
    [ReturnType(typeof(bool))]
    public class ClientIsJavascriptEngineSupportedExtension : IValueExtension
    {
        public object ProvideValue(IValueExtensionContext context)
        {
            return true;
        }
    }
}

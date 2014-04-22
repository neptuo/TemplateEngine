using Neptuo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Configuration
{
    public class IsDebugProperty : BoolConfigurationProperty
    {
        public IsDebugProperty()
            : base(true, "Application", "IsDebug")
        { }
    }
}

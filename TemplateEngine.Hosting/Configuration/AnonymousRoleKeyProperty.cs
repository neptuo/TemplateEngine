using Neptuo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Configuration
{
    public class AnonymousRoleKeyProperty : IntConfigurationProperty
    {
        public AnonymousRoleKeyProperty()
            : base(2, "Application", "AnonymousRoleKey")
        { }
    }
}

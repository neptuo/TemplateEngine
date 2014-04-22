using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Configuration
{
    public interface IApplicationConfiguration
    {
        bool IsDebug { get; }
    }
}

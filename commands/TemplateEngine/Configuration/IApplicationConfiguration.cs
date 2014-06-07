using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Configuration
{
    /// <summary>
    /// Application configuration.
    /// </summary>
    public interface IApplicationConfiguration
    {
        /// <summary>
        /// Contains debug flag.
        /// </summary>
        bool IsDebug { get; }

        /// <summary>
        /// Role key for anonynous user.
        /// </summary>
        int AnonymousRoleKey { get; }
    }
}

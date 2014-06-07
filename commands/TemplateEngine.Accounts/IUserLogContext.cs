using Neptuo.TemplateEngine.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    /// <summary>
    /// Extended <see cref="IUserContext"/> included information about current <see cref="UserLog"/>.
    /// </summary>
    public interface IUserLogContext : IUserContext
    {
        /// <summary>
        /// Current user log.
        /// </summary>
        UserLog Log { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    /// <summary>
    /// User info.
    /// </summary>
    public interface IUserInfo
    {
        /// <summary>
        /// User key.
        /// </summary>
        int Key { get; }

        /// <summary>
        /// User name.
        /// </summary>
        string Username { get; }
    }
}

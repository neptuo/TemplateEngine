using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    /// <summary>
    /// Authentication service.
    /// </summary>
    public interface IAuthenticator
    {
        /// <summary>
        /// Signs user in.
        /// </summary>
        /// <param name="username">User name.</param>
        /// <param name="password">Password.</param>
        /// <returns>True if succeed.</returns>
        bool Login(string username, string password);

        /// <summary>
        /// Signs user out.
        /// </summary>
        /// <returns>True is succeed.</returns>
        bool Logout();
    }
}

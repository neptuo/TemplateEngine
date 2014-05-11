using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security
{
    /// <summary>
    /// Context of signed user.
    /// </summary>
    public interface IUserContext
    {
        /// <summary>
        /// User info.
        /// </summary>
        IUserInfo User { get; }

        /// <summary>
        /// Permission settings.
        /// </summary>
        IPermissionProvider Permissions { get; }

        /// <summary>
        /// Token that is used to authenticate user.
        /// </summary>
        string AuthenticationToken { get; }

        /// <summary>
        /// Whether is user authenticated or is anonnymous.
        /// </summary>
        bool IsAuthenticated { get; }
    }
}

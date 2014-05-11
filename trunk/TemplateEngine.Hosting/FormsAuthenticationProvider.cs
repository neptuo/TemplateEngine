using Neptuo.Events.Handlers;
using Neptuo.TemplateEngine.Security.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Neptuo.TemplateEngine.Hosting
{
    /// <summary>
    /// Reacts to <see cref="UserSignedInEvent"/> and <see cref="UserSignedOutEvent"/>.
    /// Setups authentication cookies.
    /// </summary>
    public class FormsAuthenticationProvider : IEventHandler<UserSignedOutEvent>, IEventHandler<UserSignedInEvent>
    {
        /// <summary>
        /// Signs user out (discarts auth cookie.).
        /// </summary>
        public void Handle(UserSignedOutEvent eventData)
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// Signs user in (creates auth cookie with <see cref="eventData.UserContext.AuthenticationToken"/> as userName).
        /// </summary>
        public void Handle(UserSignedInEvent eventData)
        {
            FormsAuthentication.SetAuthCookie(eventData.UserContext.AuthenticationToken, false);
        }
    }
}

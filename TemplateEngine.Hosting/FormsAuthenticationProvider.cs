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
    public class FormsAuthenticationProvider : IEventHandler<UserSignedOutEvent>, IEventHandler<UserSignedInEvent>
    {
        public void Handle(UserSignedOutEvent eventData)
        {
            FormsAuthentication.SignOut();
        }

        public void Handle(UserSignedInEvent eventData)
        {
            FormsAuthentication.SetAuthCookie(eventData.UserContext.AuthenticationToken, false);
        }
    }
}

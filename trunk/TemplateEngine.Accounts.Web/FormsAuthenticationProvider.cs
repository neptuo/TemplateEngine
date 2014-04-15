using Neptuo.Events.Handlers;
using Neptuo.TemplateEngine.Accounts.Events;
using Neptuo.TemplateEngine.Security.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Neptuo.TemplateEngine.Accounts.Web
{
    public class FormsAuthenticationProvider : IEventHandler<UserLogCreatedEvent>, IEventHandler<UserSignedOutEvent>
    {
        public void Handle(UserLogCreatedEvent eventData)
        {
            FormsAuthentication.SetAuthCookie(eventData.Log.Key.ToString(), false);
        }

        public void Handle(UserSignedOutEvent eventData)
        {
            FormsAuthentication.SignOut();
        }
    }
}

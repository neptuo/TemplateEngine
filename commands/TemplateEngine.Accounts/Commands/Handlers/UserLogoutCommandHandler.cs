using Neptuo.Commands.Handlers;
using Neptuo.Events;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Security.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Commands.Handlers
{
    public class UserLogoutCommandHandler : ICommandHandler<UserLogoutCommand>
    {
        protected IEventDispatcher EventDispatcher { get; private set; }
        protected UserLogDataProvider UserLogs { get; private set; }
        protected IUserLogContext UserContext { get; private set; }

        public UserLogoutCommandHandler(IEventDispatcher eventDispatcher, UserLogDataProvider userLogs, IUserLogContext userContext)
        {
            EventDispatcher = eventDispatcher;
            UserLogs = userLogs;
            UserContext = userContext;
        }

        public void Handle(UserLogoutCommand command)
        {
            if (UserContext.IsAuthenticated)
            {
                UserContext.Log.LastActivity = DateTime.Now;
                UserContext.Log.SignedOut = DateTime.Now;
                UserLogs.Repository.Update(UserContext.Log);

                EventDispatcher.Publish(new UserSignedOutEvent(DateTime.Now));
            }
        }
    }
}

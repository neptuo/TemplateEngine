using Neptuo.Commands.Handlers;
using Neptuo.Events;
using Neptuo.TemplateEngine.Accounts.Data;
using Neptuo.TemplateEngine.Accounts.Data.Queries;
using Neptuo.TemplateEngine.Accounts.Events;
using Neptuo.TemplateEngine.Configuration;
using Neptuo.TemplateEngine.Security.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Commands.Handlers
{
    public class UserLoginCommandHandler : ICommandHandler<UserLoginCommand>
    {
        protected IApplicationConfiguration Configuration { get; private set; }
        protected IEventDispatcher EventDispatcher { get; private set; }
        protected UserAccountDataProvider UserAccounts { get; private set; }
        protected UserLogDataProvider UserLogs { get; private set; }
        protected IActivator<IResourcePermissionQuery> PermissionQueryFactory { get; private set; }

        public UserLoginCommandHandler(IApplicationConfiguration configuration, IEventDispatcher eventDispatcher, UserAccountDataProvider userAccounts, UserLogDataProvider userLogs, IActivator<IResourcePermissionQuery> permissionQueryFactory)
        {
            Configuration = configuration;
            EventDispatcher = eventDispatcher;
            UserAccounts = userAccounts;
            UserLogs = userLogs;
            PermissionQueryFactory = permissionQueryFactory;
        }

        public void Handle(UserLoginCommand command)
        {
            Guard.NotNull(command, "command");

            var query = UserAccounts.Query();
            query.Filter = new CredentialsAccountFilter(command.Username, command.Password);
            UserAccount account = query.ResultSingle();
            if (account != null)
            {
                UserLog log = UserLogs.Factory.Create();
                log.Key = Guid.NewGuid();
                log.SignedIn = DateTime.Now;
                log.LastActivity = DateTime.Now;
                log.User = account;
                UserLogs.Repository.Insert(log);

                EventDispatcher.Publish(new UserLogCreatedEvent(log));
                EventDispatcher.Publish(new UserSignedInEvent(new UserContextBase(Configuration, log, PermissionQueryFactory, log.Key.ToString()), log.SignedIn));
            }
        }
    }
}

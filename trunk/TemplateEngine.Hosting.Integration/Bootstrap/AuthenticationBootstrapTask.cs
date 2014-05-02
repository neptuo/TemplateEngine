using Neptuo.Bootstrap;
using Neptuo.Events;
using Neptuo.Events.Handlers;
using Neptuo.TemplateEngine.Security.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Hosting.Integration.Bootstrap
{
    public class AuthenticationBootstrapTask : IBootstrapTask
    {
        private readonly IEventRegistry eventRegistry;

        public AuthenticationBootstrapTask(IEventRegistry eventRegistry)
        {
            Guard.NotNull(eventRegistry, "eventRegistry");
            this.eventRegistry = eventRegistry;
        }

        public void Initialize()
        {
            FormsAuthenticationProvider authProvider = new FormsAuthenticationProvider();
            eventRegistry.Subscribe<UserSignedOutEvent>(new SingletonEventHandlerFactory<UserSignedOutEvent>(authProvider));
            eventRegistry.Subscribe<UserSignedInEvent>(new SingletonEventHandlerFactory<UserSignedInEvent>(authProvider));
        }
    }
}

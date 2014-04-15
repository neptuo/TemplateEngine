using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security.Events
{
    public class UserSignedInEvent
    {
        public IUserContext UserContext { get; private set; }
        public DateTime Timestamp { get; private set; }

        public UserSignedInEvent(IUserContext userContext, DateTime timestamp)
        {
            Guard.NotNull(userContext, "userContext");
            UserContext = userContext;
            Timestamp = timestamp;
        }
    }
}

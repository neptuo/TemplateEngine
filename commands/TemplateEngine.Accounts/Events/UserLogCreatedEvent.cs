using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Events
{
    public class UserLogCreatedEvent
    {
        public UserLog Log { get; private set; }

        public UserLogCreatedEvent(UserLog log)
        {
            Guard.NotNull(log, "log");
            Log = log;
        }
    }
}

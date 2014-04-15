using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Security.Events
{
    public class UserSignedOutEvent
    {
        public DateTime Timestamp { get; private set; }

        public UserSignedOutEvent(DateTime timestamp)
        {
            Timestamp = timestamp;
        }
    }
}

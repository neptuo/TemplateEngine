using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Events
{
    public class UserAccountUpdated
    {
        public int UserKey { get; set; }

        public UserAccountUpdated(int userKey)
        {
            Guard.Positive(userKey, "userKey");
            UserKey = userKey;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Events
{
    public class UserAccountDeleted
    {
        public int UserKey { get; set; }

        public UserAccountDeleted(int userKey)
        {
            Guard.Positive(userKey, "userKey");
            UserKey = userKey;
        }
    }
}

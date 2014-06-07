using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Events
{
    public class UserAccountCreated
    {
        public int UserKey { get; private set; }
        public string Username { get; private set; }

        public UserAccountCreated(int userKey, string username)
        {
            Guard.Positive(userKey, "userKey");
            Guard.NotNullOrEmpty(username, "username");
            UserKey = userKey;
            Username = username;
        }
    }
}

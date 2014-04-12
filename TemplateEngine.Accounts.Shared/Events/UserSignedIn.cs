using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Events
{
    public class UserSignedIn
    {
        public int Key { get; private set; }
        public string Username { get; private set; }

        public UserSignedIn(int key, string username)
        {
            Guard.Positive(key, "key");
            Guard.NotNullOrEmpty(username, "username");
            Key = key;
            Username = username;
        }
    }
}

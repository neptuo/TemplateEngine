using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Commands
{
    public class UserAccountDeleteCommand
    {
        public int UserKey { get; set; }

        public UserAccountDeleteCommand(int userKey)
        {
            Guard.Positive(userKey, "userKey");
            UserKey = userKey;
        }
    }
}

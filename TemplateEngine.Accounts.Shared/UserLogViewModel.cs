using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserLogViewModel
    {
        public string Key { get; set; }
        public UserAccountRowViewModel User { get; set; }
        public DateTime SignedIn { get; set; }
        public DateTime? SignedOut { get; set; }
        public DateTime? LastActivity { get; set; }
        public bool IsCurrent { get; set; }

        public UserLogViewModel(string key, UserAccountRowViewModel user, DateTime signedIn, DateTime? signedOut, DateTime? lastActivity, bool isCurrent = false)
        {
            Key = key;
            User = user;
            SignedIn = signedIn;
            SignedOut = signedOut;
            LastActivity = lastActivity;
            IsCurrent = isCurrent;
        }
    }
}

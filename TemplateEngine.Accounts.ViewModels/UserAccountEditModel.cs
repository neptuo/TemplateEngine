using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserAccountEditModel
    {
        public bool IsNew
        {
            get { return Key == 0; }
        }

        public int Key { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public bool IsEnabled { get; set; }
        public IEnumerable<int> RoleKeys { get; set; }
    }
}

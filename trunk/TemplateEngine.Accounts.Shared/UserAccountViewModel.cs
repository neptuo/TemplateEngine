using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserAccountViewModel
    {
        public int Key { get; set; }
        public string Username { get; set; }
        public bool IsEnabled { get; set; }
        public IEnumerable<UserRoleRowViewModel> Roles { get; set; }

        public UserAccountViewModel(int key, string username, bool isEnabled, IEnumerable<UserRoleRowViewModel> roles)
        {
            Key = key;
            Username = username;
            IsEnabled = isEnabled;
            Roles = roles;
        }
    }
}

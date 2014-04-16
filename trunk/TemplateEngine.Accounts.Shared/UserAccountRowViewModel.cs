using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserAccountRowViewModel
    {
        public int Key { get; set; }
        public string Username { get; set; }

        public UserAccountRowViewModel(int key, string username)
        {
            Key = key;
            Username = username;
        }
    }
}

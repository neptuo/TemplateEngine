using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserRoleRowViewModel
    {
        public int Key { get; set; }
        public string Name { get; set; }

        public UserRoleRowViewModel(int key, string name)
        {
            Key = key;
            Name = name;
        }
    }
}

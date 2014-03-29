using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserRoleViewModel
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public UserRoleViewModel(int key, string name, string description)
        {
            Key = key;
            Name = name;
            Description = description;
        }
    }
}

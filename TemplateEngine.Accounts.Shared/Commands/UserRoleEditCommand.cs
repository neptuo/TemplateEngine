using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Commands
{
    public class UserRoleEditCommand
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

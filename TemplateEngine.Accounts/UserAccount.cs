using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public abstract class UserAccount
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual List<UserRole> Roles { get; set; }
    }
}

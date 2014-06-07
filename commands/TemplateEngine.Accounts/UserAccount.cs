using Neptuo.Data;
using Neptuo.TemplateEngine.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserAccount : IKey<int>, IVersion, IUserInfo
    {
        public int Key { get; set; }
        public byte[] Version { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsEnabled { get; set; }

        public virtual List<UserRole> Roles { get; set; }
    }
}

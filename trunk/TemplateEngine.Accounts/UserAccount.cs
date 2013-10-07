using Neptuo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public abstract class UserAccount : IKey<int>, IVersion
    {
        public virtual int Key { get; set; }
        public virtual byte[] Version { get; set; }

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual bool IsEnabled { get; set; }

        public abstract List<UserRole> Roles { get; set; }
    }
}

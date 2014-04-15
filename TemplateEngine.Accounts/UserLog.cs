using Neptuo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserLog : IKey<Guid>, IVersion
    {
        public Guid Key { get; set; }
        public byte[] Version { get; set; }

        public DateTime SignedIn { get; set; }
        public DateTime LastActivity { get; set; }
        public DateTime? SignedOut { get; set; }

        public virtual UserAccount User { get; set; }
    }
}

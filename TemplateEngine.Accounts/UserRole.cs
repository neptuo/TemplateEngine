using Neptuo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class UserRole : IKey<int>, IVersion
    {
        public int Key { get; set; }
        public byte[] Version { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<UserAccount> Accounts { get; set; }
    }
}

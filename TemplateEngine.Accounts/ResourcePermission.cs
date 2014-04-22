using Neptuo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts
{
    public class ResourcePermission : IKey<int>, IVersion
    {
        public int Key { get; set; }
        public byte[] Version { get; set; }

        public string ResourceName { get; set; }
        public string PermissionName { get; set; }

        public virtual UserRole Role { get; set; }
    }
}

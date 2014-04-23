using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Controllers.Commands
{
    public class ResourcePermissionUpdateCommand
    {
        public int RoleKey { get; set; }
        public IEnumerable<string> ResourceNames { get; set; }
        public string PermissionName { get; set; }
    }
}

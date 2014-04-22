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
        public string ResourceName { get; set; }
        public IEnumerable<string> PermissionNames { get; set; }
    }
}

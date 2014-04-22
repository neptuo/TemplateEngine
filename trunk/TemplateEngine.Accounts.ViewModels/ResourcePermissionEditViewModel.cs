using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.ViewModels
{
    public class ResourcePermissionEditViewModel
    {
        public string ResourceName { get; set; }
        public string ResourceHint { get; set; }
        public IEnumerable<PermissionNameEditViewModel> Permissions { get; set; }

        public ResourcePermissionEditViewModel(string resourceName, string resourceHint, IEnumerable<PermissionNameEditViewModel> permissions)
        {
            ResourceName = resourceName;
            ResourceHint = resourceHint;
            Permissions = permissions;
        }
    }
}

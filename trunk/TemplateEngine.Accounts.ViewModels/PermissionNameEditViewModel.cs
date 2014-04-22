using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.ViewModels
{
    public class PermissionNameEditViewModel
    {
        public string ResourceName { get; set; }
        public string PermissionName { get; set; }
        public bool IsEnabled { get; set; }

        public PermissionNameEditViewModel(string resourceName, string permissionName, bool isEnabled)
        {
            ResourceName = resourceName;
            PermissionName = permissionName;
            IsEnabled = isEnabled;
        }
    }
}

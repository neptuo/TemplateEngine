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
        public string PermissionName { get; set; }
        public bool IsEnabled { get; set; }

        public ResourcePermissionEditViewModel(string resourceName, string resourceHint, string permissionName, bool isEnabled)
        {
            ResourceName = resourceName;
            ResourceHint = resourceHint;
            PermissionName = permissionName;
            IsEnabled = isEnabled;
        }
    }
}

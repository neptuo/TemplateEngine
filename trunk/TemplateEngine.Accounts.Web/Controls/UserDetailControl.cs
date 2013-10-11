using Neptuo.TemplateEngine.Web.Controls;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Accounts.Web.Controls
{
    [Html("div")]
    public class UserDetailControl : ContentControlBase
    {
        public UserDetailControl(IComponentManager componentManager)
            : base(componentManager)
        { }
    }
}

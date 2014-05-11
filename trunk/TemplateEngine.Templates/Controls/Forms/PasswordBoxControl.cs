using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Creates password input.
    /// </summary>
    public class PasswordBoxControl : TextBoxControl
    {
        public PasswordBoxControl(IComponentManager componentManager)
            : base(componentManager)
        {
            Type = "password";
        }
    }
}

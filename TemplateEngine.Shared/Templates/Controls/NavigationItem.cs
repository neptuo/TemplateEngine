using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Templates.Controls.DesignData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class NavigationItem
    {
        [Hint("Navigation result name")]
        public string Name { get; set; }

        [Hint("Form uri to navigate to.")]
        public FormUri To { get; set; }
    }
}

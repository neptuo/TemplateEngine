using Neptuo.TemplateEngine.Navigation;
using Neptuo.TemplateEngine.Templates.Controls.DesignData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Single navigation rule.
    /// </summary>
    public class NavigationItem
    {
        /// <summary>
        /// Navigation rule.
        /// </summary>
        [Hint("Navigation result name")]
        public string On { get; set; }

        /// <summary>
        /// Form to navigate to.
        /// </summary>
        [Hint("Form uri to navigate to.")]
        public FormUri To { get; set; }
    }
}

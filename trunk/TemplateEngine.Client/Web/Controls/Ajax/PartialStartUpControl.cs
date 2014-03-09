using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class PartialStartUpControl : IControl
    {
        public string DefaultUpdate { get; set; }

        public void OnInit()
        {
            Guard.NotNull(DefaultUpdate, "DefaultUpdate");
        }

        public void Render(IHtmlWriter writer)
        { }
    }
}

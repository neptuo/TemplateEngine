using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class TemplateContentControl : ContentControlBase
    {
        public string Name { get; set; }

        public TemplateContentControl(IComponentManager componentManager)
            : base(componentManager)
        { }
    }
}

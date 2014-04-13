using Neptuo.TemplateEngine.Providers;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class PostFormControl : HtmlContentControlBase
    {
        public PostFormControl(IComponentManager componentManager, ICurrentUrlProvider urlProvider)
            : base(componentManager, "form")
        {
            Attributes["method"] = "post";
            Attributes["action"] = urlProvider.GetCurrentUrl();
        }
    }
}

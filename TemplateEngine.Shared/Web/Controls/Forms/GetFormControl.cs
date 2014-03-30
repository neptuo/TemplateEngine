using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class GetFormControl : HtmlContentControlBase
    {
        public GetFormControl(IComponentManager componentManager, ICurrentUrlProvider urlProvider)
            : base(componentManager, "form")
        {
            Attributes["method"] = "get";
            Attributes["action"] = urlProvider.GetCurrentUrl();
        }
    }
}

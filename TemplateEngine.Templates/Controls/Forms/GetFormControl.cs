using Neptuo.TemplateEngine.Providers;
using Neptuo.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Creates form that is sumitted by get.
    /// </summary>
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

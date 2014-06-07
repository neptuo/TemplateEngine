using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    /// <summary>
    /// Javascript implementation of <see cref="BundleControl"/>.
    /// </summary>
    public abstract class ClientBundleControl : BundleControlBase
    {
        public ClientBundleControl(IVirtualUrlProvider urlProvider)
            : base(urlProvider)
        { }
    }
}

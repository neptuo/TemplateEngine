using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public abstract class BundleControl : BundleControlBase
    {
        public BundleControl(IVirtualUrlProvider urlProvider)
            : base(urlProvider)
        { }
    }
}

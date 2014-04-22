using Neptuo.TemplateEngine.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class ClientDropDownListControl : ClientSelectControl
    {
        public string ID { get; set; }
        public string CssStyle { get; set; }
        public string CssClass { get; set; }

        public ClientDropDownListControl(PartialUpdateHelper partialHelper, SelectControlContext context)
            : base(partialHelper, context)
        { }

        public override void OnInit()
        {
            if (ID == null)
                ID = Name;

            base.OnInit();
        }
    }
}

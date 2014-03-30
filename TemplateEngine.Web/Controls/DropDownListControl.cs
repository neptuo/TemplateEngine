using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class DropDownListControl : SelectControl
    {
        public string ID { get; set; }
        public string CssStyle { get; set; }
        public string CssClass { get; set; }

        public DropDownListControl(SelectControlContext context)
            : base(context)
        { }

        public override void OnInit()
        {
            if (ID == null)
                ID = Name;

            base.OnInit();
        }
    }
}

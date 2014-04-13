using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates.Controls
{
    public class DoctypeControl : IControl
    {
        public DoctypeType Type { get; set; }

        public void OnInit()
        { }

        public void Render(IHtmlWriter writer)
        {
            switch (Type)
            {
                case DoctypeType.Xhtml:
                    writer.Content("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
                    break;
                case DoctypeType.Html5:
                default:
                    writer.Content("<!DOCTYPE html>");
                    break;
            }
        }
    }

    public enum DoctypeType
    {
        Html5,
        Xhtml
    }
}

using Neptuo.Templates;
using Neptuo.Templates.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Web.Controls
{
    public class DoctypeControl : IControl
    {
        public void OnInit()
        { }

        public void Render(IHtmlWriter writer)
        {
            writer.Content("<!DOCTYPE html>");
        }
    }
}

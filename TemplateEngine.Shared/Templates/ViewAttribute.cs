using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    public class ViewAttribute : Attribute
    {
        public string ViewPath { get; set; }

        public ViewAttribute(string viewPath)
        {
            ViewPath = viewPath;
        }
    }
}

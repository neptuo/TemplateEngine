using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.TemplateEngine.Templates
{
    /// <summary>
    /// Attribute that defines view path in generated class.
    /// </summary>
    public class ViewAttribute : Attribute
    {
        public string ViewPath { get; set; }

        public ViewAttribute(string viewPath)
        {
            ViewPath = viewPath;
        }
    }
}
